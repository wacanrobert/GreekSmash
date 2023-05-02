using AutoMapper;
using GreekSmash.Dtos.Hero;
using GreekSmash.Models;

namespace GreekSmash.Mappings
{
    public class HeroMappings : Profile
    {
        public HeroMappings()
        {
            CreateMap<Hero, HeroDto>();
            CreateMap<HeroCreationDto, Hero>();
            CreateMap<HeroDto, Hero>();
        }
    }
}
