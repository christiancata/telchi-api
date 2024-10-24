using Microsoft.Extensions.DependencyInjection;
using Telchi.DataAccess.Interfaces;
using Telchi.DataAccess.Repositories;
using Telchi.SAPDataAccess.Interfaces;
using Telchi.SAPDataAccess.Repositories;
using Telchi.Services.Implementations.SAP;
using Telchi.Services.Interfaces.SAP;

namespace Telchi.Services
{
    public static class DependencyInjection
    {
        #region Metodos
        /// <summary>
        /// Se agrega las dependencias de nuestras clases
        /// </summary>
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IConfiguracionSAPRepository, ConfiguracionSAPRepository>();

            services.AddTransient<ISAPQuotationRepository, SAPQuotationRepository>()
                .AddTransient<ISAPQuotationService, SAPQuotationService>();

            services.AddTransient<ISAPInvoiceRepository, SAPInvoiceRepository>()
                .AddTransient<ISAPInvoiceService, SAPInvoiceService>();

            return services;
        }
        #endregion
    }
}