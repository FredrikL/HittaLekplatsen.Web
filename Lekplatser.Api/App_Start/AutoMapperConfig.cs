using AutoMapper;
using Lekplatser.Api.Models;
using Lekplatser.Dto;
using MongoDB.Bson;

namespace Lekplatser.Api.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<ObjectId, string>().ConvertUsing(o => o.ToString());
            Mapper.CreateMap<string, ObjectId>().ConvertUsing(s => ObjectId.Parse(s));

            Mapper.CreateMap<Location, LocationEntity>()
                .ForMember(l => l.lat, o => o.MapFrom(le => le.Lat))
                .ForMember(l => l.lng, o => o.MapFrom(le => le.Long));

            Mapper.CreateMap<LocationEntity, Location>()
                .ForMember(le => le.Lat, o => o.MapFrom(l => l.lat))
                .ForMember(le => le.Long, o => o.MapFrom(l => l.lng));

            Mapper.CreateMap<Playground, PlaygroundEntity>()
                .ForMember(pe => pe.Id, o=> o.NullSubstitute(ObjectId.Empty))
                .ForMember(pe => pe.Loc, o => o.MapFrom(p => Mapper.Map<Location,LocationEntity>(p.Location)))
                .ForMember(pe => pe.Rating, o => o.Ignore()); // for now

            Mapper.CreateMap<PlaygroundEntity, Playground>()
                .ForMember(p => p.Location, o => o.MapFrom(pe => Mapper.Map<LocationEntity, Location>(pe.Loc)));

        }
    }
}