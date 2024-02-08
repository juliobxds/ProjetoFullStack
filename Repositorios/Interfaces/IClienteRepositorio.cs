using ProjetoFullStack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFullStack.Repositorios.Interfaces {
    public interface IClienteRepositorio {

        Task<List<ClienteModel>> BuscarTodosClientes();
        Task<ClienteModel> BuscarClientePorId(int id); // buscar usuario por Id
        Task<ClienteModel> AdicionarCliente(ClienteModel cliente); 
        Task<ClienteModel> AtualizarCliente(ClienteModel cliente, int id); 
        Task<bool> DeletarCliente(int id); 
    }
}
