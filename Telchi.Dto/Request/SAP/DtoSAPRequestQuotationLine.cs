namespace Telchi.Dto.Request.SAP
{
    public class DtoSAPRequestQuotationLine
    {
        #region Propiedades
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double Quantity { get; set; }
        public string WarehouseCode { get; set; }
        public double PriceAfterVAT { get; set; }
        public string TaxCode { get; set; }
        public double PorcentajeDeCobertura { get; set; }
        #endregion
        #region Constructores
        public DtoSAPRequestQuotationLine()
        {
            ItemCode = string.Empty;
            ItemDescription = string.Empty;
            WarehouseCode = string.Empty;
            TaxCode = string.Empty;
        }
        #endregion
    }
}