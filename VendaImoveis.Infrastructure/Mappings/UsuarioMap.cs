using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class UsuarioMap<T> : RegistroMap<T> where T : Usuario
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();

            builder.HasIndex(x => x.NomeUsuario).IsUnique();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Senha).IsRequired();

            builder.Property(x => x.Telefone).IsRequired();

            builder.HasOne(x => x.TipoUsuario)
                   .WithMany()
                   .HasForeignKey(x => x.TipoUsuarioId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Imobiliaria)
                   .WithMany()
                   .HasForeignKey(x => x.ImobiliariaId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
