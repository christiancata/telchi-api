using AutoMapper;
using Telchi.DataAccess.Interfaces;
using Telchi.Dto.Request.SAP;
using Telchi.Dto.Response;
using Telchi.Entities.SAP;
using Telchi.SAPDataAccess.Interfaces;
using Telchi.Services.Interfaces.SAP;

namespace Telchi.Services.Implementations.SAP
{
    public class SAPInvoiceService : SAPConnectionService, ISAPInvoiceService
    {
        #region Propiedades
        private readonly IConfiguracionSAPRepository _configuracionSAPRepository;
        private readonly ISAPInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructores
        public SAPInvoiceService(IConfiguracionSAPRepository configuracionSAPRepository, ISAPInvoiceRepository quotationRepository, IMapper mapper)
        {
            _configuracionSAPRepository = configuracionSAPRepository;
            _invoiceRepository = quotationRepository;
            _mapper = mapper;
        }
        #endregion
        #region Metodos
        public async Task<BaseResponseCollection> Update(DtoSAPRequestInvoiceCollection request)
        {
            var response = new BaseResponseCollection();

            var configuracionSAP = await _configuracionSAPRepository.GetAsync();

            if (configuracionSAP != null)
            {
                var loginResponse = await Login(configuracionSAP);

                if (loginResponse.Success)
                {
                    int row = 0;

                    foreach (DtoSAPRequestInvoice invoiceRequest in request.Invoices)
                    {
                        row++;

                        var invoice = _mapper.Map<SAPInvoice>(invoiceRequest);

                        var invoiceResponse = await _invoiceRepository.Update(configuracionSAP.ServiceLayerUrl, loginResponse.Result, invoice);

                        if (!invoiceResponse.Success)
                        {
                            response.ErrorList.Add(invoiceResponse.Error);
                        }
                    }

                    if (response.ErrorList.Count == 0)
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
                    response.ErrorList.Add(loginResponse.Error);
                }
            }
            else
            {
                response.Success = false;

                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Code = 600;
                errorResponse.Message = Message.GetError(600);

                response.ErrorList.Add(errorResponse);
            }

            return response;
        }
        #endregion
    }
}