using GreekSmash.Dtos.Location;
using GreekSmash.Models;

namespace GreekSmash.Dtos.Condition
{
    public class ConditionDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public List<LocationGetterDto> Locations { get; set; } = new List<LocationGetterDto>();
    }
}
