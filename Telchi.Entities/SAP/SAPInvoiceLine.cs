using System.Text.Json.Serialization;

namespace Telchi.Entities.SAP
{
    public class SAPInvoiceLine
    {
        #region Propiedades
        public int LineNum { get; set; }
        [JsonPropertyName("U_Creada")]
        public string Creada { get; set; }
        #endregion
        #region Constructores
        public SAPInvoiceLine()
        {
            Creada = string.Empty;
        }
        #endregion
    }
}