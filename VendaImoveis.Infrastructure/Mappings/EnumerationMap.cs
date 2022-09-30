using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class EnumerationMap<T> : IEntityTypeConfiguration<T> where T : Enumeration
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.Property(x => x.Name)
                   .IsRequired();
        }
    }
}
