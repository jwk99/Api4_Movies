using Api4_Movies.Data;
using Api4_Movies.DTO;
using Api4_Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api4_Movies.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _db;
        public MoviesController(MovieDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _db.Movies
                .GroupJoin(
                    _db.Ratings,
                    m => m.Id,
                    r => r.MovieId,
                    (m, ratings) => new MovieRankingDto(
                        m.Id,
                        m.Title,
                        m.Year,
                        ratings.Any()
                            ? Math.Round(ratings.Average(r => (decimal)r.Score), 2)
                            : 0,
                        ratings.Count()
                        )
                    )
                .ToListAsync();
            var ordered = movies
                .OrderByDescending(m => m.AvgScore)
                .ThenByDescending(m => m.Votes)
                .ToList();
                
            return Ok(ordered);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieCreateDto dto)
        {
            if(string.IsNullOrWhiteSpace(dto.Title))
            {
                return UnprocessableEntity("Title is required");
            }
            var movie = new Movie
            {
                Title = dto.Title,
                Year = dto.Year,
            };
            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovies),new { id = movie.Id },null);
        }
    }
}
