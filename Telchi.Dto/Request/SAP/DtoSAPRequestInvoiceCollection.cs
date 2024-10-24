namespace Telchi.Dto.Request.SAP
{
    public class DtoSAPRequestInvoiceCollection
    {
        #region Propiedades
        public ICollection<DtoSAPRequestInvoice> Invoices { get; set; }
        #endregion
        #region Constructores
        public DtoSAPRequestInvoiceCollection()
        {
            Invoices = new List<DtoSAPRequestInvoice>();
        }
        #endregion
    }
}