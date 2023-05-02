using System.ComponentModel.DataAnnotations;

namespace GreekSmash.Dtos.Villain
{
    public class VillainCreationDto
    {
        [Required(ErrorMessage = "The villain name is required.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name of the villain is 30 characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The villain perkId is required.")]
        [Range(1,6, ErrorMessage = "Villain perkId must be between 1-6")]
        public int? PerkId { get; set; }
        [Required(ErrorMessage = "The villain weapon is required.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name of the weapon is 30 characters.")]
        public string? Weapon { get; set; }
        [Required(ErrorMessage = "The villain description is required.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the name of the villain is 50 characters.")]
        public string? Description { get; set; }
    }
}
