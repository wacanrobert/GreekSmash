using AutoMapper;
using GreekSmash.Dtos.Condition;
using GreekSmash.Dtos.Location;
using GreekSmash.Models;

namespace GreekSmash.Mappings
{
    public class ConditionMappings : Profile
    {
        public ConditionMappings()
        {
            CreateMap<Condition, ConditionDto>();
            CreateMap<ConditionCreationDto, Condition>();
            CreateMap<ConditionDto, Condition>();
            CreateMap<Condition, ConditionGetterDto>();
        }
    }
}
