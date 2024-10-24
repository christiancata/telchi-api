using System.Text.Json.Serialization;

namespace Telchi.Entities.SAP
{
    public class SAPInvoice
    {
        #region Propiedades
        [JsonIgnore]
        public int DocEntry { get; set; }
        [JsonPropertyName("U_Creada")]
        public string Creada { get; set; }
        [JsonPropertyName("U_Sincronizada")]
        public string Sincronizada { get; set; }
        public ICollection<SAPInvoiceLine> DocumentLines { get; set; }
        #endregion
        #region Constructores
        public SAPInvoice()
        {
            Creada = string.Empty;
            Sincronizada = string.Empty;
            DocumentLines = new List<SAPInvoiceLine>();
        }
        #endregion
    }
}