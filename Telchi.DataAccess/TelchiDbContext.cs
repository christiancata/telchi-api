using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Telchi.DataAccess
{
    public class TelchiDbContext : DbContext
    {
        #region Constructores
        public TelchiDbContext() { }
        public TelchiDbContext(DbContextOptions<TelchiDbContext> options) : base(options) { }
        #endregion
        #region Metodos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var entityTypes = modelBuilder.Model
                .GetEntityTypes()
                .ToList();

            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));

            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        #endregion
    }
}