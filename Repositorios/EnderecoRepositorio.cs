using ProjetoFullStack.Data;
using ProjetoFullStack.Domain.Models;
using ProjetoFullStack.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFullStack.Repositorios
{
    public class EnderecoRepositorio : IEnderecoRepositorio {

        private readonly PFSDBContext _context;

        public EnderecoRepositorio(PFSDBContext pfsDBContext) {
            _context = pfsDBContext;
        }

        public Task<List<EnderecoModel>> BuscarTodosEndereco() {
            throw new System.NotImplementedException();
        }
        public Task<EnderecoModel> BuscarEnderecoPorId(int id) {
            throw new System.NotImplementedException();
        }

        public Task<EnderecoModel> AdicionarEndereco(EnderecoModel endereco) {
            throw new System.NotImplementedException();
        }

        public Task<EnderecoModel> AtualizarEndereco(EnderecoModel endereco, int id) {
            throw new System.NotImplementedException();
        }


        public Task<bool> DeletarEndereco(int id) {
            throw new System.NotImplementedException();
        }
    }
}
