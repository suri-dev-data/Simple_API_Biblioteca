using AutoMapper;
using LivroAPI.Models;
using LivroAPI.Data.Dtos;

namespace LivroAPI.Profiles
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile() 
        {
            CreateMap<CreatePessoaDto, Pessoa>();
            CreateMap<UpdatePessoaDto, Pessoa>();
            CreateMap<Pessoa, ReadPessoaDto>()
                .ForMember(pessoaDto => pessoaDto.Endereco,
                opt => opt.MapFrom(pessoa => pessoa.Endereco)) 
                .ForMember(pessoaDto => pessoaDto.Emprestimos,
                opt => opt.MapFrom(pessoa => pessoa.Emprestimos));
        }
    }
}
