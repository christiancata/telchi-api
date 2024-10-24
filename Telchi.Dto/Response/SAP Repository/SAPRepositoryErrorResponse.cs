using System.Text.Json.Serialization;

namespace Telchi.Dto.Response.SAP_Repository
{
    public class SAPRepositoryErrorResponse
    {
        #region Propiedades
        [JsonPropertyName("error")]
        public DtoSAPRepositoryResponseError Error { get; set; }
        #endregion
        #region Constructores
        public SAPRepositoryErrorResponse()
        {
            Error = new DtoSAPRepositoryResponseError();
        }
        #endregion
    }
}