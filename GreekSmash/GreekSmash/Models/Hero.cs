using Newtonsoft.Json;
namespace GreekSmash.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? PerkID { get; set; }
        public string? Weapon { get; set; }
        public string? Description { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
