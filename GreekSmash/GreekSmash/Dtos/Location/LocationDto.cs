using GreekSmash.Dtos.Condition;
using GreekSmash.Models;

namespace GreekSmash.Dtos.Location
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<ConditionGetterDto> Conditions { get; set; } = new List<ConditionGetterDto>();

    }
}
