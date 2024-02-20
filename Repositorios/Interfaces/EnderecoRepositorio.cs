using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoFullStack.Data;
using ProjetoFullStack.Domain.DTOS;
using ProjetoFullStack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFullStack.Repositorios.Interfaces {
    public class EnderecoRepositorio : IEnderecoRepositorio {
        private readonly PFSDBContext _context;
        //private readonly IMapper _mapper;

        public EnderecoRepositorio(PFSDBContext context) {
            _context = context;
       }

        //public EnderecoRepositorio(IMapper mapper) {
        //    _mapper = mapper;
        //}

        async Task<List<EnderecoModel>> IEnderecoRepositorio.BuscarTodosEnderecos() {
            return await _context.Enderecos.ToListAsync();
        }
        async Task<EnderecoModel> IEnderecoRepositorio.BuscarEnderecoPorId(int id) {
            return await _context.Enderecos.FirstOrDefaultAsync(x => x.Id == id);
       }
        //async Task<EnderecoDto> IEnderecoRepositorio.AdicionarEndereco(EnderecoDto endereco) {
            //    EnderecoModel enderecoModel = new EnderecoModel() { NomeDaRua = endereco.NomeDaRua, Bairro = endereco.Bairro, NumeroDaRua = endereco.NumeroDaRua };
            //    var enderecoMap = _mapper.Map<EnderecoDto>(enderecoModel);
            //    await _context.Clientes.AddAsync(enderecoMap);
            //    await _context.SaveChangesAsync();

            //    return enderecoMap;
        //}

        Task<EnderecoModel> IEnderecoRepositorio.AtualizarEndereco(EnderecoDto endereco, int id) {
            throw new System.NotImplementedException();
        }



        Task<bool> IEnderecoRepositorio.DeletarEndereco(int id) {
            throw new System.NotImplementedException();
        }

        public Task<EnderecoModel> AdicionarEndereco(EnderecoModel endereco) {
          throw new System.NotImplementedException();
        }

        public Task<EnderecoDto> AdicionarEndereco(EnderecoDto endereco) {
            throw new System.NotImplementedException();
        }
    }
}
