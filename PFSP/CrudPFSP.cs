using AutoMapper;
using ProjetoFullStack.Domain.DTOS;
using ProjetoFullStack.Domain.Models;

namespace ProjetoFullStack.PFSP {
    public class CrudPFSP : Profile {
        public CrudPFSP() {

            CreateMap<ClienteModel, ClienteDto>().ReverseMap();
            CreateMap<EnderecoModel, EnderecoDto>().ReverseMap();

        }
    }
}
