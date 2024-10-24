using System.Text.Json.Serialization;

namespace Telchi.Entities.SAP
{
    public class SAPQuotation
    {
        #region Propiedades
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }
        public string CardCode { get; set; }
        public double DocTotal { get; set; }
        public string Comments { get; set; }
        public string TaxDate { get; set; }
        [JsonPropertyName("U_Usuario")]
        public string Usuario { get; set; }
        [JsonPropertyName("U_ProformaSeguro"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ProformaSeguro { get; set; }
        [JsonPropertyName("U_CodigoDeAsegurado")]
        public string CodigoDeAsegurado { get; set; }
        [JsonPropertyName("U_NombreDeAsegurado")]
        public string NombreDeAsegurado { get; set; }
        [JsonPropertyName("U_Poliza")]
        public string Poliza { get; set; }
        [JsonPropertyName("U_Certificado")]
        public int Certificado { get; set; }
        [JsonPropertyName("U_CodigoDeTarjeta")]
        public string CodigoDeTarjeta { get; set; }
        [JsonPropertyName("U_CodigoDeMedico")]
        public string CodigoDeMedico { get; set; }
        [JsonPropertyName("U_NombreDeMedico")]
        public string NombreDeMedico { get; set; }
        [JsonPropertyName("U_CodigoDePatologia")]
        public string CodigoDePatologia { get; set; }
        [JsonPropertyName("U_NombreDePatologia")]
        public string NombreDePatologia { get; set; }
        [JsonPropertyName("U_Oficina")]
        public int Oficina { get; set; }
        [JsonPropertyName("U_PorcentajeDeCobertura")]
        public decimal PorcentajeDeCobertura { get; set; }
        [JsonPropertyName("U_NumeroDeOrden")]
        public string NumeroDeOrden { get; set; }
        [JsonPropertyName("U_AutorizadoPor")]
        public string AutorizadoPor { get; set; }
        [JsonPropertyName("U_Adjunto")]
        public string Adjunto { get; set; }
        public ICollection<SAPQuotationLine> DocumentLines { get; set; }
        #endregion
        #region Constructores
        public SAPQuotation()
        {
            DocDate = string.Empty;
            DocDueDate = string.Empty;
            CardCode = string.Empty;
            Comments = string.Empty;
            TaxDate = string.Empty;
            Usuario = string.Empty;
            CodigoDeAsegurado = string.Empty;
            NombreDeAsegurado = string.Empty;
            Poliza = string.Empty;
            CodigoDeTarjeta = string.Empty;
            CodigoDeMedico = string.Empty;
            NombreDeMedico = string.Empty;
            CodigoDePatologia = string.Empty;
            NombreDePatologia = string.Empty;
            NumeroDeOrden = string.Empty;
            AutorizadoPor = string.Empty;
            Adjunto = string.Empty;
            DocumentLines = new List<SAPQuotationLine>();
        }
        #endregion
    }
}