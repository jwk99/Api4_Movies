using Api4_Movies.Data;
using Api4_Movies.DTO;
using Api4_Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api4_Movies.Controllers
{
    [ApiController]
    [Route("api/ratings")]
    public class RatingsController : ControllerBase
    {
        private readonly MovieDbContext _db;
        public RatingsController(MovieDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> AddRating(RatingCreateDto dto)
        {
            if(dto.Score<1||dto.Score>5)
            {
                return UnprocessableEntity("Score must be between 1 and 5");
            }
            var movieExists = await _db.Movies
                .AnyAsync(m => m.Id == dto.MovieId);
            if (!movieExists)
            {
                return NotFound("Movie not found");
            }
            var rating = new Rating
            {
                MovieId = dto.MovieId,
                Score = dto.Score,
            };
            _db.Ratings.Add(rating);
            await _db.SaveChangesAsync();
            return Ok(rating);
        }
    }
}
