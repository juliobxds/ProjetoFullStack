using Microsoft.EntityFrameworkCore;
using ProjetoFullStack.Data.Map;
using ProjetoFullStack.Domain.Models;

namespace ProjetoFullStack.Data
{
    public class PFSDBContext : DbContext {

        public PFSDBContext(DbContextOptions<PFSDBContext> options)
            : base(options)
        {
        }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
