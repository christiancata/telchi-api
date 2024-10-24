using System.Text.Json.Serialization;

namespace Telchi.Entities.SAP
{
    public class SAPQuotationLine
    {
        #region Propiedades
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double Quantity { get; set; }
        public string WarehouseCode { get; set; }
        public double PriceAfterVAT { get; set; }
        public string TaxCode { get; set; }
        [JsonPropertyName("U_PorcentajeDeCobertura")]
        public double PorcentajeDeCobertura { get; set; }
        #endregion
        #region Constructores
        public SAPQuotationLine()
        {
            ItemCode = string.Empty;
            ItemDescription = string.Empty;
            WarehouseCode = string.Empty;
            TaxCode = string.Empty;
        }
        #endregion
    }
}