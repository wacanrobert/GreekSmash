using Newtonsoft.Json;

namespace GreekSmash.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Condition> Conditions { get; set; } = new List<Condition>();
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
