using System.ComponentModel.DataAnnotations;

namespace Api4_Movies.DTO
{
    public record MovieCreateDto(
        [Required]
        [StringLength(200)]
        string Title,
        [Range(1888, 2100)]
        int Year
        );
}
