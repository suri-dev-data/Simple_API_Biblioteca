using AutoMapper;
using LivroAPI.Models;
using LivroAPI.Data.Dtos;

namespace LivrariaAPI.Profiles
{
    public class LivrariaProfile : Profile
    {
        public LivrariaProfile() 
        {
            CreateMap<CreateLivrariaDto, Livraria>();
            CreateMap<UpdateLivrariaDto, Livraria>();
            CreateMap<Livraria, ReadLivrariaDto>()
                .ForMember(livrariaDto => livrariaDto.Endereco,
                opt => opt.MapFrom(livraria => livraria.Endereco))
                .ForMember(livrariaDto => livrariaDto.Livros,
                opt => opt.MapFrom(livraria => livraria.Livros)); 
        }
    }
}
