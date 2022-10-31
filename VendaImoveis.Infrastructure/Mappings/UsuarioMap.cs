using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class UsuarioMap<T> : RegistroMap<T> where T : Usuario
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.NomeUsuario).IsUnique();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Senha).IsRequired();

            builder.HasOne(x => x.TipoUsuario)
                   .WithMany()
                   .HasForeignKey(x => x.TipoUsuarioId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
