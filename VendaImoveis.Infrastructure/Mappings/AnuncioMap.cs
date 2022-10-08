using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class AnuncioMap : RegistroMap<Anuncio>
    {
        public override void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Descricao).HasMaxLength(256);

            builder.HasOne(x => x.Imobiliaria)
                   .WithMany(x => x.Anuncios)
                   .HasForeignKey(x => x.ImobiliariaId)
                   .IsRequired()
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(x => x.Propriedade)
                   .WithMany(x => x.Anuncios)
                   .HasForeignKey(x => x.PropriedadeId)
                   .IsRequired()
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
