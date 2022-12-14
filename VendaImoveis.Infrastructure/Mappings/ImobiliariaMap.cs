using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class ImobiliariaMap : UsuariosImobiliariaMap<Imobiliaria>
    {
        public override void Configure(EntityTypeBuilder<Imobiliaria> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.CNPJ).IsUnique();
            builder.Property(x => x.CNPJ).HasMaxLength(18);

            builder.HasOne(x => x.Endereco)
                   .WithMany()
                   .HasForeignKey(x => x.EnderecoId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Corretores)
                   .WithOne(x => x.Imobiliaria)
                   .HasForeignKey(x => x.ImobiliariaId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.TipoUsuarioId).HasDefaultValue(1);
        }
    }
}
