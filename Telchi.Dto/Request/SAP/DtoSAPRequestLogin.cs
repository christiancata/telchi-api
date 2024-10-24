namespace Telchi.Dto.Request.SAP
{
    public class DtoSAPRequestLogin
    {
        #region Propiedades
        public string CompanyDB { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Language { get; set; }
        #endregion
        #region Constructores
        public DtoSAPRequestLogin()
        {
            CompanyDB = string.Empty;
            Password = string.Empty;
            UserName = string.Empty;
            Language = string.Empty;
        }
        #endregion
    }
}