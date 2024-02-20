using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFullStack.Domain.Models;

namespace ProjetoFullStack.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel> {
        public void Configure(EntityTypeBuilder<ClienteModel> builder) {
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Celular).IsRequired().HasMaxLength(128);
            builder.HasOne(x => x.Endereco).WithOne(x => x.Cliente).HasForeignKey<EnderecoModel>(x => x.ClienteModelId);
        }
    }
}
