using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telchi.Entities.Telchi;

namespace Telchi.DataAccess.Configurations
{
    public class ConfiguracionSAPConfiguration : IEntityTypeConfiguration<ConfiguracionSAP>
    {
        #region Metodos
        public void Configure(EntityTypeBuilder<ConfiguracionSAP> builder)
        {
            builder.Property(p => p.APIUrl)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(p => p.ServiceLayerUrl)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(p => p.Schema)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(p => p.UserName)
                .HasMaxLength(100).
                IsUnicode(false);

            builder.Property(p => p.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
        #endregion
    }
}