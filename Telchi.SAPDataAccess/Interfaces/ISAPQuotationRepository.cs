using System.Net;
using Telchi.Dto.Request.SAP;
using Telchi.Dto.Response;
using Telchi.Entities.SAP;

namespace Telchi.SAPDataAccess.Interfaces
{
    public interface ISAPQuotationRepository
    {
        #region Metodos
        Task<BaseResponseGeneric<int>> Add(string _url, CookieCollection cookieCollection, SAPQuotation quotation);
        Task<BaseResponse> Cancel(string _url, CookieCollection cookieCollection, int docEntry);
        #endregion
    }
}