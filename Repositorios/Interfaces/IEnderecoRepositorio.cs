using ProjetoFullStack.Domain.DTOS;
using ProjetoFullStack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFullStack.Repositorios.Interfaces {
    public interface IEnderecoRepositorio {
        Task<List<EnderecoModel>> BuscarTodosEnderecos();
        Task<EnderecoModel> BuscarEnderecoPorId(int id); // buscar usuario por Id
        Task<EnderecoDto> AdicionarEndereco(EnderecoDto endereco);
        Task<EnderecoModel> AtualizarEndereco(EnderecoDto endereco, int id);
        Task<bool> DeletarEndereco(int id);
    }
}
