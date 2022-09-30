using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class PropriedadeMap : RegistroMap<Propriedade>
    {
        public override void Configure(EntityTypeBuilder<Propriedade> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).IsRequired();


            builder.Property(x => x.Endereco).IsRequired();

            builder.OwnsOne(x => x.Endereco, end =>
            {
                end.Property(c => c.Rua).HasMaxLength(100).IsRequired();

                end.Property(c => c.Bairro).HasMaxLength(30).IsRequired();

                end.Property(c => c.CEP).HasMaxLength(9).IsRequired();

                end.Property(c => c.Cidade).HasMaxLength(20).IsRequired();

                end.Property(c => c.Estado).HasMaxLength(2).IsRequired();
            });

            builder.Property(x => x.AreaTotal).IsRequired();

            builder.Property(x => x.AreaConstruida).IsRequired();

            builder.Property(x => x.Valor).IsRequired();

            builder.HasOne(x => x.TipoImovel)
                   .WithMany()
                   .HasForeignKey(x => x.TipoImovelId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
