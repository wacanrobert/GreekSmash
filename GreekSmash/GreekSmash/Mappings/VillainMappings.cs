using AutoMapper;
using GreekSmash.Dtos.Villain;
using GreekSmash.Models;

namespace GreekSmash.Mappings
{
    public class VillainMappings : Profile
    {
        public VillainMappings()
        {
            CreateMap<Villain, VillainDto>();
            CreateMap<VillainCreationDto, Villain>();
            CreateMap<VillainDto, Villain>();
        }
    }
}
