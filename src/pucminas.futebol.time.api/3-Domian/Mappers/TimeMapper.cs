using AutoMapper;
using pucminas.futebol.time.api._3_Domian.DTOS;
using pucminas.futebol.time.api._3_Domian.Entidades;

namespace pucminas.futebol.time.api._3_Domian.Mappers
{
    public class TimeMapper : Profile
    {
        public TimeMapper()
        {
            CreateMap<Time, TimeResponseDTO>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id.ToString())
                )
                .ForMember(
                    dest => dest.DataCadastro,
                    opt => opt.MapFrom(src => src.Criacao.ToString("dd-MM-yyyy"))
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Nome)
                )
                .ForMember(
                    dest => dest.Cidade,
                    opt => opt.MapFrom(src => src.Cidade)
                )
                .ForMember(
                    dest => dest.Pais,
                    opt => opt.MapFrom(src => src.Pais)
                )
                .ForMember(
                    dest => dest.DataFundacao,
                    opt => opt.MapFrom(src => src.DataFundacao.ToString("dd-MM-yyyy"))
                );
        }
    }
}
