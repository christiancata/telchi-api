namespace Telchi.Dto.Request.SAP
{
    public class DtoSAPRequestQuotationCollection
    {
        #region Propiedades
        public ICollection<DtoSAPRequestQuotation> Quotations { get; set; }
        #endregion
        #region Constructores
        public DtoSAPRequestQuotationCollection()
        {
            Quotations = new List<DtoSAPRequestQuotation>();
        }
        #endregion
    }
}