using AutoMapper;
using Telchi.DataAccess.Interfaces;
using Telchi.Dto.Request.SAP;
using Telchi.Dto.Response;
using Telchi.Entities.SAP;
using Telchi.SAPDataAccess.Interfaces;
using Telchi.Services.Interfaces.SAP;

namespace Telchi.Services.Implementations.SAP
{
    public class SAPQuotationService : SAPConnectionService, ISAPQuotationService
    {
        #region Propiedades
        private readonly IConfiguracionSAPRepository _configuracionSAPRepository;
        private readonly ISAPQuotationRepository _quotationRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructores
        public SAPQuotationService(IConfiguracionSAPRepository configuracionSAPRepository, ISAPQuotationRepository quotationRepository, IMapper mapper)
        {
            _configuracionSAPRepository = configuracionSAPRepository;
            _quotationRepository = quotationRepository;
            _mapper = mapper;
        }
        #endregion
        #region Metodos
        public async Task<BaseResponseGeneric<ICollection<int>>> Add(DtoSAPRequestQuotationCollection request)
        {
            var response = new BaseResponseGeneric<ICollection<int>>();
            response.Result = new List<int>();

            var configuracionSAP = await _configuracionSAPRepository.GetAsync();

            if (configuracionSAP != null)
            {
                var loginResponse = await Login(configuracionSAP);

                if (loginResponse.Success)
                {
                    int row = 0;

                    foreach (DtoSAPRequestQuotation quotationRequest in request.Quotations)
                    {
                        row++;

                        var quotation = _mapper.Map<SAPQuotation>(quotationRequest);

                        if (row == 2)
                        {
                            quotation.ProformaSeguro = response.Result.ElementAt(0);
                        }

                        var quotationResponse = await _quotationRepository.Add(configuracionSAP.ServiceLayerUrl, loginResponse.Result, quotation);

                        if (quotationResponse.Success)
                        {
                            response.Result.Add(quotationResponse.Result);
                        }
                        else
                        {
                            response.Error = quotationResponse.Error;

                            if (row == 2)
                            {
                                var cancelQuotationResponse = await _quotationRepository.Cancel(configuracionSAP.ServiceLayerUrl, loginResponse.Result, response.Result.ElementAt(0));

                                response.Result = new List<int>();
                            }

                            break;
                        }
                    }

                    if (response.Error.Code == 0)
                    {
                        response.Success = true;
                    }
                    else
                    {
                        response.Success = false;
                    }

                    await Logout(configuracionSAP.ServiceLayerUrl, loginResponse.Result);
                }
                else
                {
                    response.Success = false;
                    response.Error = loginResponse.Error;
                }
            }
            else
            {
                response.Success = false;

                response.Error.Code = 600;
                response.Error.Message = Message.GetError(600);
            }

            return response;
        }
        public async Task<BaseResponse> Cancel(int docEntry)
        {
            var response = new BaseResponse();

            var configuracionSAP = await _configuracionSAPRepository.GetAsync();

            if (configuracionSAP != null)
            {
                var loginResponse = await Login(configuracionSAP);

                if (loginResponse.Success)
                {
                    response = await _quotationRepository.Cancel(configuracionSAP.ServiceLayerUrl, loginResponse.Result, docEntry);

                    await Logout(configuracionSAP.ServiceLayerUrl, loginResponse.Result);
                }
                else
                {
                    response.Success = false;
                    response.Error = loginResponse.Error;
                }
            }
            else
            {
                response.Success = false;

                response.Error.Code = 600;
                response.Error.Message = Message.GetError(600);
            }

            return response;
        }
        #endregion
    }
}