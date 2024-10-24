using System.Net;
using Telchi.Dto.Response;
using Telchi.Entities.SAP;

namespace Telchi.SAPDataAccess.Interfaces
{
    public interface ISAPInvoiceRepository
    {
        #region Metodos
        Task<BaseResponse> Update(string _url, CookieCollection cookieCollection, SAPInvoice invoice);
        #endregion
    }
}