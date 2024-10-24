using System.Text.Json.Serialization;

namespace Telchi.Dto.Response.SAP_Repository
{
    public class DtoSAPRepositoryResponseMessage
    {
        #region Propiedades
        [JsonPropertyName("lang")]
        public string Lang { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
        #endregion
        #region Constructores
        public DtoSAPRepositoryResponseMessage()
        {
            Lang = string.Empty;
            Value = string.Empty;
        }
        #endregion
    }
}