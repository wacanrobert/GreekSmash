

using System.ComponentModel.DataAnnotations;

namespace GreekSmash.Dtos.Location
{
    public class LocationCreationDto
    {
        [Required(ErrorMessage = "The location name is required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the name of the location is 40 characters.")]
        public string? Name { get; set; }
    }
}
