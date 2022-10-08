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

            builder.HasOne(x => x.Endereco)
                   .WithMany()
                   .HasForeignKey(x => x.EnderecoId)
                   .IsRequired()
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder.Property(x => x.AreaTotal).HasPrecision(20,2).IsRequired();

            builder.Property(x => x.AreaConstruida).HasPrecision(20, 2);

            builder.Property(x => x.Valor).HasPrecision(20, 2).IsRequired();

            builder.HasOne(x => x.TipoImovel)
                   .WithMany()
                   .HasForeignKey(x => x.TipoImovelId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
