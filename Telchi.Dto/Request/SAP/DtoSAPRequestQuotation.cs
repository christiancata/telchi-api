namespace Telchi.Dto.Request.SAP
{
    public class DtoSAPRequestQuotation
    {
        #region Propiedades
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }
        public string CardCode { get; set; }
        public double DocTotal { get; set; }
        public string Comments { get; set; }
        public string TaxDate { get; set; }
        public string Usuario { get; set; }
        public string CodigoDeAsegurado { get; set; }
        public string NombreDeAsegurado { get; set; }
        public string Poliza { get; set; }
        public int Certificado { get; set; }
        public string CodigoDeTarjeta { get; set; }
        public string CodigoDeMedico { get; set; }
        public string NombreDeMedico { get; set; }
        public string CodigoDePatologia { get; set; }
        public string NombreDePatologia { get; set; }
        public int Oficina { get; set; }
        public decimal PorcentajeDeCobertura { get; set; }
        public string NumeroDeOrden { get; set; }
        public string AutorizadoPor { get; set; }
        public string Adjunto { get; set; }
        public ICollection<DtoSAPRequestQuotationLine> DocumentLines { get; set; }
        #endregion
        #region Constructores
        public DtoSAPRequestQuotation()
        {
            DocDate = string.Empty;
            DocDueDate = string.Empty;
            CardCode = string.Empty;
            Comments = string.Empty;
            TaxDate = string.Empty;
            Usuario = string.Empty;
            CodigoDeAsegurado = string.Empty;
            NombreDeAsegurado = string.Empty;
            CodigoDeTarjeta = string.Empty;
            CodigoDeMedico = string.Empty;
            NombreDeMedico = string.Empty;
            CodigoDePatologia = string.Empty;
            NombreDePatologia = string.Empty;
            Poliza = string.Empty;
            NumeroDeOrden = string.Empty;
            AutorizadoPor = string.Empty;
            Adjunto = string.Empty;
            DocumentLines = new List<DtoSAPRequestQuotationLine>();
        }
        #endregion
    }
}