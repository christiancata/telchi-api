using Telchi.Entities.Telchi;

namespace Telchi.DataAccess.Interfaces
{
    public interface IConfiguracionSAPRepository
    {
        #region Metodos
        Task<ConfiguracionSAP?> GetAsync();
        #endregion
    }
}