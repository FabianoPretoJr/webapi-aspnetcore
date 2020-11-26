using AutoMapper;
using smartschool.DTO;
using smartschool.Models;

namespace smartschool.helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}"))
                .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge()));

            CreateMap<AlunoDTO, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDTO>().ReverseMap();
        }
    }
}