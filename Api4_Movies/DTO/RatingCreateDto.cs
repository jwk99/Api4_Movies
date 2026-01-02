using System.ComponentModel.DataAnnotations;

namespace Api4_Movies.DTO
{
    public record RatingCreateDto
    (
        [Required]
        int MovieId,
        [Range(1, 5)]
        int Score
    );
}
