namespace Telchi.Dto.Request.SAP
{
    public class DtoSAPRequestInvoiceLine
    {
        #region Propiedades
        public int LineNum { get; set; }
        public string Creada { get; set; }
        #endregion
        #region Constructores
        public DtoSAPRequestInvoiceLine()
        {
            Creada = string.Empty;
        }
        #endregion
    }
}