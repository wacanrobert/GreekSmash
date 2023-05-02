using Newtonsoft.Json;

namespace GreekSmash.Models
{
    public class Condition
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public List<Location> Locations { get; set; } = new List<Location>();
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
