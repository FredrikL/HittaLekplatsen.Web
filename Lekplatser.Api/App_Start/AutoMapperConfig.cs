using AutoMapper;
using Lekplatser.Api.Models;
using Lekplatser.Dto;

namespace Lekplatser.Api.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Playground, PlaygroundEntity>()
                .ForMember(pe => pe.Lat, o => o.MapFrom(p => p.Location.Lat))
                .ForMember(pe => pe.Long, o => o.MapFrom(p => p.Location.Long));

            Mapper.CreateMap<PlaygroundEntity, Playground>()
                .ForMember(p => p.Location, o => o.MapFrom(pe => new Location(pe.Lat, pe.Long)));

            Mapper.AssertConfigurationIsValid();
        }
    }
}