

using System.ComponentModel.DataAnnotations;

namespace GreekSmash.Dtos.Condition
{
    public class ConditionCreationDto
    {
        [Required(ErrorMessage = "The location description is required.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the description of the location is 60 characters.")]
        public string? Description { get; set; }
    }
}
