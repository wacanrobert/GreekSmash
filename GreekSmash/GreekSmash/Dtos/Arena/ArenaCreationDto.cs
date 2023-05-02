using System.ComponentModel.DataAnnotations;

namespace GreekSmash.Dtos.Arena
{
    public class ArenaCreationDto
    {
        [Required(ErrorMessage = "Hero Id is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Hero Id must be at least 1.")]
        public int HeroId { get; set; }

        [Required(ErrorMessage = "Villain Id is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Villain Id must be at least 1.")]
        public int VillainId { get; set; }

        [Required(ErrorMessage = "Location Id is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Location Id must be at least 1.")]
        public int LocationId { get; set; }
    }
}
