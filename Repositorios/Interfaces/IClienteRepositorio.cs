using ProjetoFullStack.Domain.DTOS;
using ProjetoFullStack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFullStack.Repositorios.Interfaces {
    public interface IClienteRepositorio {

        Task<List<ClienteDto>> BuscarTodosClientes();
        Task<ClienteDto> BuscarClientePorId(int id); // buscar usuario por Id
        Task<ClienteDto> AdicionarCliente(ClienteDto cliente);
        Task<ClienteModel> AtualizarCliente(ClienteDto cliente, int id);
        Task<bool> DeletarCliente(int id);
    }
}