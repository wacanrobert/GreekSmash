using AutoMapper;
using GreekSmash.Dtos.Arena;
using GreekSmash.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreekSmash.Mappings
{
    public class ArenaMappings : Profile
    {
        public ArenaMappings()
        {
            CreateMap<Arena, ArenaDto>()
                .ForMember(dto => dto.Hero, opt => opt.MapFrom(ar => ar.Hero!.Name))
                .ForMember(dto => dto.Villain, opt => opt.MapFrom(ar => ar.Villain!.Name))
                .ForMember(dto => dto.Location, opt => opt.MapFrom(ar => ar.Location!.Name));
        }
    }
}
