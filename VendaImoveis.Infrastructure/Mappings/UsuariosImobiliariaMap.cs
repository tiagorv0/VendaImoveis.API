using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class UsuariosImobiliariaMap<T> : UsuarioMap<T>
        where T : UsuariosImobiliaria
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();

            builder.HasIndex(x => x.CRECI).IsUnique();

            builder.Property(x => x.Telefone).HasMaxLength(15).IsRequired();
        }
    }
}
