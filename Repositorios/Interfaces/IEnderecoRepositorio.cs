using ProjetoFullStack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFullStack.Repositorios.Interfaces
{
    public interface IEnderecoRepositorio {

        Task<List<EnderecoModel>> BuscarTodosEndereco();
        Task<EnderecoModel> BuscarEnderecoPorId(int id); // buscar usuario por Id
        Task<EnderecoModel> AdicionarEndereco(EnderecoModel endereco);
        Task<EnderecoModel> AtualizarEndereco(EnderecoModel endereco, int id);
        Task<bool> DeletarEndereco(int id);
    }
}
