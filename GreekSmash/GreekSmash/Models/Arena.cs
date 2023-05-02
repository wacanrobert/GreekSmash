using Newtonsoft.Json;

namespace GreekSmash.Models
{
    public class Arena
    {
        public int Id { get; set; }
        public Hero? Hero { get; set; }
        public Villain? Villain { get; set; }
        public Location? Location { get; set; }
        public List<Condition> Conditions { get; set; } = new List<Condition>();
        public string? Result { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
