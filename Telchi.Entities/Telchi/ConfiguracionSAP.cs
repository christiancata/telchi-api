namespace Telchi.Entities.Telchi
{
    public class ConfiguracionSAP
    {
        #region Propiedades
        public int Id { get; set; }
        public string APIUrl { get; set; }
        public string ServiceLayerUrl { get; set; }
        public string Schema { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        #endregion
        #region Constructores
        public ConfiguracionSAP()
        {
            APIUrl = string.Empty;
            ServiceLayerUrl = string.Empty;
            Schema = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
        }
        #endregion
    }
}