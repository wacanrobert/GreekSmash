using AutoMapper;
using GreekSmash.Dtos.Location;
using GreekSmash.Dtos.Villain;
using GreekSmash.Models;

namespace GreekSmash.Mappings
{
    public class LocationMappings : Profile
    {
        public LocationMappings()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<Location, LocationGetterDto>();
            CreateMap<LocationCreationDto, Location>();
            CreateMap<LocationCreationDto, LocationGetterDto>();
            CreateMap<Location, LocationGetterDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(ar => ar.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(ar => ar.Name));
        }
    }
}
