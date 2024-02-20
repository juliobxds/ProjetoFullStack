using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoFullStack.Data;
using ProjetoFullStack.Domain.DTOS;
using ProjetoFullStack.Domain.Models;
using ProjetoFullStack.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFullStack.Repositorios {
    public class ClienteRepositorio : IClienteRepositorio {
        private readonly PFSDBContext _context;
        //private readonly IMapper _mapper;
        public ClienteRepositorio(PFSDBContext pfsDBContext) {
            _context = pfsDBContext;

        }
        //public ClienteRepositorio(IMapper mapper) {
        //    _mapper = mapper;
        //}

        public async Task<List<ClienteDto>> BuscarTodosClientes() {

            var listaClientes = await _context.Clientes.Include(x => x.Endereco).AsNoTracking().ToListAsync(); // Método de buscar a lista dos Clientes!

            var listaClientesDto = new List<ClienteDto>();

            foreach (var clienteModel in listaClientes) {

                var clienteDto = new ClienteDto();
                clienteDto.Id = clienteModel.Id;
                clienteDto.Nome = clienteModel.Nome;
                clienteDto.Email = clienteModel.Email;
                clienteDto.EnderecoDto = new EnderecoDto();

                if (clienteModel.Endereco != null) {
                    clienteDto.EnderecoDtoId = clienteModel.Endereco.Id;
                    clienteDto.EnderecoDto.Id = clienteModel.Endereco.Id;
                    clienteDto.EnderecoDto.NomeDaRua = clienteModel.Endereco.NomeDaRua;
                    clienteDto.EnderecoDto.ClienteDtoId = clienteModel.Id;
                }

                listaClientesDto.Add(clienteDto);
            };

            return listaClientesDto;
        }
        public async Task<ClienteDto> BuscarClientePorId(int id) {
            var clienteModel = await _context.Clientes.Include(x => x.Endereco).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id); // método lambda para criar uma condiçao!!

            var clienteDto = new ClienteDto();
            clienteDto.Id = clienteModel.Id;
            clienteDto.Nome = clienteModel.Nome;
            clienteDto.Email = clienteModel.Email;
            clienteDto.EnderecoDto = new EnderecoDto();

            if (clienteModel.Endereco != null) {
                clienteDto.EnderecoDtoId = clienteModel.Endereco.Id;
                clienteDto.EnderecoDto.Id = clienteModel.Endereco.Id;
                clienteDto.EnderecoDto.NomeDaRua = clienteModel.Endereco.NomeDaRua;
                clienteDto.EnderecoDto.ClienteDtoId = clienteModel.Id;
            }
            return clienteDto;
        }
        public async Task<ClienteDto> AdicionarCliente(ClienteDto cliente) {
            ClienteModel clienteModel = new ClienteModel() {
                Nome = cliente.Nome,
                Celular = cliente.Celular,
                Email = cliente.Email,
                Endereco = new EnderecoModel() {
                    NomeDaRua = cliente.EnderecoDto.NomeDaRua,
                    NumeroDaRua = cliente.EnderecoDto.NumeroDaRua,
                    Bairro = cliente.EnderecoDto.Bairro,
                    Id = cliente.EnderecoDto.Id
                }
            };

            //var clienteMap = _mapper.Map<ClienteDto>(clienteModel);

            var clienteSalvo = await _context.Clientes.AddAsync(clienteModel);
            await _context.SaveChangesAsync();

            var clienteResposta = new ClienteDto() {
                Nome = clienteSalvo.Entity.Nome,
                Email = clienteSalvo.Entity.Email
            };
            return clienteResposta;
        }
        public async Task<ClienteModel> AtualizarCliente(ClienteDto cliente, int id) {
            //var clientePorId = await BuscarClientePorId(id);
            //if (clientePorId != null) {
            //    throw new Exception($"Cliente Para o ID:{id} não foi encontrado");
            //}
            //cliente.Id = cliente.Id;
            //cliente.Nome = cliente.Nome;
            //cliente.Email = cliente.Email;
            //cliente.Celular = cliente.Celular;

            //_context.Clientes.Update(clientePorId);
            //await _context.SaveChangesAsync();

            //return clientePorId;
            throw new System.NotImplementedException();


        }
        public async Task<bool> DeletarCliente(int id) {
            var clienteDto = await BuscarClientePorId(id);

            if (clienteDto == null) {
                throw new Exception($"Cliente Para o ID:{id} não foi encontrado");
            }
            ClienteModel clienteModel = new ClienteModel() { Id = clienteDto.Id};

            _context.Clientes.Remove(clienteModel);


            await _context.SaveChangesAsync();
            return true;
            throw new System.NotImplementedException();

        }
    }
}
