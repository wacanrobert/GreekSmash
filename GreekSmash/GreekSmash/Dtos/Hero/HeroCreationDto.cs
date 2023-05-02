using System.ComponentModel.DataAnnotations;
namespace GreekSmash.Dtos.Hero
{
    public class HeroCreationDto
    {
        [Required(ErrorMessage = "The hero name is required.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name of the hero is 30 characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The hero perkId is required.")]
        [Range(1, 6, ErrorMessage = "Hero perkId must be between 1-6")]
        public int? PerkId { get; set; }
        [Required(ErrorMessage = "The hero weapon is required.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name of the weapon is 30 characters.")]
        public string? Weapon { get; set; }
        [Required(ErrorMessage = "The hero description is required.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the name of the hero is 50 characters.")]
        public string? Description { get; set; }
    }
}
