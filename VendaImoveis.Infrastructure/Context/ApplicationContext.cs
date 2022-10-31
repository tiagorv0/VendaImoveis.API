using Microsoft.EntityFrameworkCore;
using VendaImoveis.Domain.Core;
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
        public virtual DbSet<Anuncio> Anuncios { get; set; }
        public virtual DbSet<Propriedade> Propriedades { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            modelBuilder.ApplyConfiguration(new EnumerationMap<UserRole>());
            modelBuilder.Entity<UserRole>().HasData(Enumeration.GetAll<UserRole>());

            modelBuilder.ApplyConfiguration(new EnumerationMap<PropertyType>());
            modelBuilder.Entity<PropertyType>().HasData(Enumeration.GetAll<PropertyType>());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-ONMGS4I;Database=VendaImoveisDB;Integrated Security=true;pooling=true");
        }
    }
}
