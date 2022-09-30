using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class CorretorMap : UsuarioMap<Corretor>
    {
        public override void Configure(EntityTypeBuilder<Corretor> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CPF).HasMaxLength(14).IsRequired();
        }
    }
}
