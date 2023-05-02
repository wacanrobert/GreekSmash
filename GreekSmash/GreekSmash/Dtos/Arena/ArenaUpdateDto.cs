using System.ComponentModel.DataAnnotations;

namespace GreekSmash.Dtos.Arena
{
    public class ArenaUpdateDto
    {
        [Required(ErrorMessage = "New result is required.")]
        public string? Result { get; set; }
    }
}
