using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class VendaMap : RegistroMap<Venda>
    {
        public override void Configure(EntityTypeBuilder<Venda> builder)
        {
            //base.Configure(builder);

            //builder.HasOne(x => x.Anuncio)
            //       .WithMany()
            //       .HasForeignKey(x => x.AnuncioId)
            //       .IsRequired()
            //       .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            //builder.HasOne(x => x.Corretor)
            //       .WithMany()
            //       .HasForeignKey(x => x.CorretorId)
            //       .IsRequired()
            //       .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
