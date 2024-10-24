using Telchi.Dto.Request.SAP;
using Telchi.Dto.Response;

namespace Telchi.Services.Interfaces.SAP
{
    public interface ISAPQuotationService
    {
        #region Metodos
        Task<BaseResponseGeneric<ICollection<int>>> Add(DtoSAPRequestQuotationCollection request);
        Task<BaseResponse> Cancel(int docEntry);
        #endregion
    }
}