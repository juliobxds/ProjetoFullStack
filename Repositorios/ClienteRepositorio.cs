using Microsoft.EntityFrameworkCore;
using ProjetoFullStack.Data;
using ProjetoFullStack.Domain.Models;
using ProjetoFullStack.Repositorios.Interfaces;
using ProjetoFullStack.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFullStack.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio {
        private readonly PFSDBContext _context;
        public ClienteRepositorio(PFSDBContext pfsDBContext) {
            _context = pfsDBContext;
        }
        public async Task<List<ClienteModel>> BuscarTodosClientes() {

            return await _context.Clientes.Include(x => x.Endereco).ToListAsync(); // Método de buscar a lista dos Clientes!
        }
        public async Task<ClienteModel> BuscarClientePorId(int id) {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id); // método lambda para criar uma condiçao!!
        }
        public async Task<ClienteModel> AdicionarCliente(ClienteModel cliente) {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }
            public async Task<ClienteModel> AtualizarCliente(ClienteModel cliente, int id) {
            var clienteId = await BuscarClientePorId(id); // método para buscar pelo Id do cliente para ocorrer a atualizaçao nos prox passos!

            if (clienteId != null) {
                throw new Exception($"Cliente Para o ID:{id} não foi encontrado");
            }

            clienteId.Nome = cliente.Nome;
            clienteId.Email = cliente.Email;
            clienteId.Celular = cliente.Celular;

            _context.Clientes.Update(clienteId);
            await _context.SaveChangesAsync();

            return cliente;

        }

        public async Task<bool> DeletarCliente(int id) {
            var clienteId = await BuscarClientePorId(id);

            if (clienteId != null) {
                throw new Exception($"Cliente Para o ID:{id} não foi encontrado");
            }
            _context.Clientes.Remove(clienteId);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
