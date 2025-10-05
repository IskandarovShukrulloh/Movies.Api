using Microsoft.EntityFrameworkCore;
using Movies.Api.Entities;

namespace Movies.Api.Data
{
    public class MoviesContext(DbContextOptions<MoviesContext> options)
        : DbContext(options)
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Genre> Genres => Set<Genre>();
    }
}