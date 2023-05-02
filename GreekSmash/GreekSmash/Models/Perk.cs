using Newtonsoft.Json;

namespace GreekSmash.Models
{
    public class Perk
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
