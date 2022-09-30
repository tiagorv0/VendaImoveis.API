using Microsoft.EntityFrameworkCore;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Entities.Enums;
using VendaImoveis.Infrastructure.Mappings;

namespace VendaImoveis.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public virtual DbSet<Imobiliaria> Imobiliarias { get; set; }
        public virtual DbSet<Corretor> Corretores { get; set; }
        public virtual DbSet<ImobiliariaPropriedade> ImobiliariaPropriedades { get; set; }
        public virtual DbSet<Propriedade> Propriedades { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            modelBuilder.ApplyConfiguration(new EnumerationMap<UserRole>());

            modelBuilder.ApplyConfiguration(new EnumerationMap<PropertyType>());
        }
    }
}
