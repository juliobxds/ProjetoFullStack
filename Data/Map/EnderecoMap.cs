using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFullStack.Domain.Models;

namespace ProjetoFullStack.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoModel> {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder) {
            
            builder.HasKey(e => e.Id);
            builder.Property(e => e.NomeDaRua).IsRequired().HasMaxLength(256);
            builder.Property(e => e.NumeroDaRua).IsRequired();
            builder.Property(e => e.Bairro).IsRequired().HasMaxLength(256);
            builder.Property(e => e.ClienteModelId).HasColumnName("ClienteModelId");
        }
    }
}
