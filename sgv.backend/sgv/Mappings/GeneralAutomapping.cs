using AutoMapper;
using sgv.Core.DTOs;
using sgv.Core.Entities;
using System.Data;

namespace sgv.Mappings;

public class GeneralAutomapping : Profile
{
    public GeneralAutomapping()
    {
        CreateMap<DataRow, Articulo>()
            .ForMember(dest => dest.PlanesDePago, opt => opt.MapFrom(src => new List<PlanDePago>())); 
        CreateMap<DataRow, PlanDePago>();
        CreateMap<Articulo, ArticuloDTO>()
            .ForMember(dest => dest.PlanesDePago, opt => opt.MapFrom(src => src.PlanesDePago));
        CreateMap<PlanDePago, PlanDePagoDTO>();
    }
}
