using AutoMapper;
using LivroAPI.Models;
using LivroAPI.Data.Dtos;

namespace EmprestimoAPI.Profiles
{
    public class EmprestimoProfile : Profile
    {
        public EmprestimoProfile()
        {
            CreateMap<CreateEmprestimoDto, Emprestimo>();
            CreateMap<UpdateEmprestimoDto, Emprestimo>();
            CreateMap<Emprestimo, ReadEmprestimoDto>(); 
        }
    }
}
