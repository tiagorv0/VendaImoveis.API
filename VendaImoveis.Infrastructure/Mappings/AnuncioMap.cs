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

            builder.HasOne(x => x.Corretor)
                   .WithMany()
                   .HasForeignKey(x => x.CorretorId)
                   .IsRequired()
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder.HasOne(x => x.Propriedade)
                   .WithMany()
                   .HasForeignKey(x => x.PropriedadeId)
                   .IsRequired()
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
