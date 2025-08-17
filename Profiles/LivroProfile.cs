using AutoMapper;
using LivroAPI.Models;
using LivroAPI.Data.Dtos;

namespace LivroAPI.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<CreateLivroDto, Livro>();
            CreateMap<UpdateLivroDto, Livro>();
            CreateMap<Livro, UpdateLivroDto>();
            CreateMap<Livro, ReadLivroDto>();
        }
    }
}
