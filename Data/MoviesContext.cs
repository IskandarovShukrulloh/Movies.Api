using Microsoft.EntityFrameworkCore;
using Movies.Api.Entities;

namespace Movies.Api.Data
{
    public class MoviesContext(DbContextOptions<MoviesContext> options)
        : DbContext(options)
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Genre> Genres => Set<Genre>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new { Id = 1, Name = "Adventure" },
                new { Id = 2, Name = "Action" },
                new { Id = 3, Name = "Drama" },
                new { Id = 4, Name = "Comedy"},
                new { Id = 5, Name = "Horror"},
                new { Id = 6, Name = "Sci-Fi"},
                new { Id = 7, Name = "Documentary"}
            );
        }
    }
}