using GreekSmash.Dtos.Condition;
using GreekSmash.Dtos.Location;

namespace GreekSmash.Dtos.Arena
{
    public class ArenaDto
    {
        public int Id { get; set; }
        public GreekSmash.Models.Hero? Hero { get; set; }
        public GreekSmash.Models.Villain? Villain { get; set; }
        public LocationDto? Location { get; set; }
        public string? Result { get; set; }
    }
}
