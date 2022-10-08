using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Infrastructure.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Rua).HasMaxLength(80).IsRequired();

            builder.Property(x => x.Bairro).HasMaxLength(20);

            builder.Property(x => x.CEP).HasMaxLength(9).IsRequired();

            builder.Property(x => x.Cidade).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Estado).HasMaxLength(2).IsRequired();
        }
    }
}
