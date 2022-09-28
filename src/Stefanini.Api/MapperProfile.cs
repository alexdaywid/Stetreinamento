using AutoMapper;
using Stefanini.Api.Dto;
using Stefanini.Business;

namespace Stefanini.Api
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Pessoa, PessoaDto>()
            .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
            .ReverseMap();

            CreateMap<Cidade, CidadeDto>().ReverseMap();
        }
    }
}
