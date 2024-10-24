namespace Telchi.Dto.Request.SAP
{
    public class DtoSAPRequestInvoice
    {
        #region Propiedades
        public int DocEntry { get; set; }
        public string Creada { get; set; }
        public string Sincronizada { get; set; }
        public ICollection<DtoSAPRequestInvoiceLine> DocumentLines { get; set; }
        #endregion
        #region Constructores
        public DtoSAPRequestInvoice()
        {
            Creada = string.Empty;
            Sincronizada = string.Empty;
            DocumentLines = new List<DtoSAPRequestInvoiceLine>();
        }
        #endregion
    }
}