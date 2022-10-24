using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class RegistroMap<T> : IEntityTypeConfiguration<T> where T : Registro
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.Property(x => x.UpdatedAt);
        }
    }
}
