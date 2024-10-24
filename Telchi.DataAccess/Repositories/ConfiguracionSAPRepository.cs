using Microsoft.EntityFrameworkCore;
using Telchi.DataAccess.Interfaces;
using Telchi.Entities.Telchi;

namespace Telchi.DataAccess.Repositories
{
    public class ConfiguracionSAPRepository: IConfiguracionSAPRepository
    {
        #region Propiedades
        private readonly TelchiDbContext _context;
        #endregion
        #region Constructores
        public ConfiguracionSAPRepository(TelchiDbContext context)
        {
            _context = context;
        }
        #endregion
        #region Metodos
        public async Task<ConfiguracionSAP?> GetAsync()
        {
            var configuracionSAP = await _context.Set<ConfiguracionSAP>()
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id == 1);

            return configuracionSAP;
        }
        #endregion
    }
}