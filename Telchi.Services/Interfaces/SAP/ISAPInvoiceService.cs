using Telchi.Dto.Request.SAP;
using Telchi.Dto.Response;

namespace Telchi.Services.Interfaces.SAP
{
    public interface ISAPInvoiceService
    {
        #region Metodos
        Task<BaseResponseCollection> Update(DtoSAPRequestInvoiceCollection request);
        #endregion
    }
}