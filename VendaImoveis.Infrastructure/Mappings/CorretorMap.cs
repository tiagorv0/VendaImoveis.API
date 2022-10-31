using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class CorretorMap : UsuariosImobiliariaMap<Corretor>
    {
        public override void Configure(EntityTypeBuilder<Corretor> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.CPF).IsUnique();
            builder.Property(x => x.CPF).HasMaxLength(14);

            builder.Property(x => x.TipoUsuarioId).HasDefaultValue(2);
        }
    }
}
