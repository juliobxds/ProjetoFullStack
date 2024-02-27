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
                clienteDto.Celular = clienteModel.Celular;
                clienteDto.EnderecoDto = new EnderecoDto();

                if (clienteModel.Endereco != null) {
                    clienteDto.EnderecoDtoId = clienteModel.Endereco.Id;
                    clienteDto.EnderecoDto.Id = clienteModel.Endereco.Id;
                    clienteDto.EnderecoDto.NomeDaRua = clienteModel.Endereco.NomeDaRua;
                    clienteDto.EnderecoDto.NumeroDaRua = clienteModel.Endereco.NumeroDaRua;
                    clienteDto.EnderecoDto.Bairro = clienteModel.Endereco.Bairro;
                    clienteDto.EnderecoDto.ClienteDtoId = clienteModel.Id;
                }

                listaClientesDto.Add(clienteDto);
            };

            return listaClientesDto;
        }
        public async Task<ClienteDto> BuscarClientePorId(int id) {
            var clienteModel = await _context.Clientes.Include(x => x.Endereco).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id); // método lambda para criar uma condiçao!!
            var clienteDto = new ClienteDto();

            if (clienteModel != null) {
                clienteDto.Id = clienteModel.Id;
                clienteDto.Nome = clienteModel.Nome;
                clienteDto.Email = clienteModel.Email;
                clienteDto.Celular = clienteModel.Celular;
                clienteDto.EnderecoDto = new EnderecoDto();

                if (clienteModel.Endereco != null) {
                    clienteDto.EnderecoDtoId = clienteModel.Endereco.Id;
                    clienteDto.EnderecoDto.Id = clienteModel.Endereco.Id;
                    clienteDto.EnderecoDto.NomeDaRua = clienteModel.Endereco.NomeDaRua;
                    clienteDto.EnderecoDto.NumeroDaRua  = clienteModel.Endereco.NumeroDaRua;
                    clienteDto.EnderecoDto.Bairro = clienteModel.Endereco.Bairro;
                    clienteDto.EnderecoDto.ClienteDtoId = clienteModel.Id;
                }
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
        public async Task<ClienteDto> AtualizarCliente(ClienteDto cliente) {

            var clienteDtoBanco = await BuscarClientePorId(cliente.Id) ?? throw new Exception($"Cliente Para o ID:{cliente.Id} não foi encontrado");

            ClienteModel clienteModel = new ClienteModel() {
                Id = clienteDtoBanco.Id,
                Nome = clienteDtoBanco.Nome,
                Celular = clienteDtoBanco.Celular,
                Email = clienteDtoBanco.Email,
                EnderecoModelId = clienteDtoBanco.EnderecoDtoId,
                Endereco = new EnderecoModel() {
                    Id = clienteDtoBanco.EnderecoDto.Id,
                    NomeDaRua = clienteDtoBanco.EnderecoDto.NomeDaRua,
                    NumeroDaRua = clienteDtoBanco.EnderecoDto.NumeroDaRua,
                    Bairro = clienteDtoBanco.EnderecoDto.Bairro, 
                    ClienteModelId = clienteDtoBanco.EnderecoDto.ClienteDtoId,
                }
            }; 
            _context.Clientes.Update(clienteModel);
            await _context.SaveChangesAsync(); // automapper prox passo!!

            return clienteDtoBanco;

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
        }
    }
}
