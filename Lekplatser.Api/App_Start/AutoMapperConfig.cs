using AutoMapper;
using Lekplatser.Api.Models;
using Lekplatser.Dto;

namespace Lekplatser.Api.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Playground, PlaygroundEntity>().ReverseMap();

            Mapper.AssertConfigurationIsValid();
        }
    }
}