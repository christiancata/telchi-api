using System.Text.Json.Serialization;

namespace Telchi.Dto.Response.SAP_Repository
{
    public class DtoSAPRepositoryResponseError
    {
        #region Propiedades
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("message")]
        public DtoSAPRepositoryResponseMessage Message { get; set; }
        #endregion
        #region Constructores
        public DtoSAPRepositoryResponseError()
        {
            Message = new DtoSAPRepositoryResponseMessage();
        }
        #endregion
    }
}