using AutoMapper;
using InstruccionesDron.Api.DTOs;
using InstruccionesDron.Domain.Models;

namespace InstruccionesDron.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DatosDronModel, DatosDronDto>().ReverseMap();
            CreateMap<InstruccionRequestModel, InstruccionRequestDto>().ReverseMap();
            CreateMap<InstruccionResponseModel, InstruccionResponseDto>().ReverseMap();
            CreateMap<PosicionDronModel, PosicionDronDto>().ReverseMap();
            CreateMap<TamañoRectanguloModel, TamañoRectanguloDto>().ReverseMap();
        }
    }
}
