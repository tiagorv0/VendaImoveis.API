using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class ImobiliariaMap : RegistroMap<Imobiliaria>
    {
        public override void Configure(EntityTypeBuilder<Imobiliaria> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.CNPJ).IsUnique();

            builder.HasIndex(x => x.Creci).IsUnique();

            builder.OwnsOne(x => x.Endereco, end =>
            {
                end.Property(c => c.Rua).HasMaxLength(100).IsRequired();

                end.Property(c => c.Bairro).HasMaxLength(30).IsRequired();

                end.Property(c => c.CEP).HasMaxLength(9).IsRequired();

                end.Property(c => c.Cidade).HasMaxLength(20).IsRequired();

                end.Property(c => c.Estado).HasMaxLength(2).IsRequired();
            });

            builder.HasMany(p => p.PropriedadesDaImobiliaria)
                   .
        }
    }
}
