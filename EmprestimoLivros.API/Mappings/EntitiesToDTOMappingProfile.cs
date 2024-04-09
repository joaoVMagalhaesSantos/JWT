using AutoMapper;
using EmprestimoLivros.API.DTOs;
using EmprestimoLivros.API.Models;


namespace EmprestimoLivros.API.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Livro, LivroDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            
        }
    }
}
