using Api4_Movies.Models;
using Microsoft.EntityFrameworkCore;

namespace Api4_Movies.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options){}
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Rating> Ratings => Set<Rating>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasCheckConstraint("CK_Ratings_Score", "[Score] BETWEEN 1 AND 5");
            modelBuilder.Entity<Rating>()
                .HasOne<Movie>()
                .WithMany()
                .HasForeignKey(r=>r.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
