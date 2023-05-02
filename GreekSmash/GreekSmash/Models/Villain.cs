using Newtonsoft.Json;

namespace GreekSmash.Models
{
    public class Villain
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? PerkId { get; set; }
        public string? Weapon { get; set; }
        public string? Description { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
