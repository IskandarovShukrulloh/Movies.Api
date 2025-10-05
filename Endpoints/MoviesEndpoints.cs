using Microsoft.EntityFrameworkCore;
using Movies.Api.Data;
using Movies.Api.DTOs;
using Movies.Api.Entities;
using Movies.Api.Mapping;

namespace Movies.Api.Endpoints
{
    public static class Endpoints
    {
        public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/movies").WithParameterValidation();
            const string GetMovieById = "GetMovie";

            // GET
            group.MapGet("/", async (MoviesContext dbContext) =>
                await dbContext.Movies.Include(m => m.Genre)
                                .Select(m => m.ToMovieSummaryDto())
                                .AsNoTracking()
                                .ToListAsync()
            );

            // GET by ID
            group.MapGet("/{id:int}", async (int id, MoviesContext dbContext) =>
            {
                Movie? movie = await dbContext.Movies.FindAsync(id);

                return movie is null
                       ? Results.NotFound()
                       : Results.Ok(movie.ToMovieDetailsDto());
            }).WithName(GetMovieById);

            // POST
            group.MapPost("/", async (CreateMovieDto newMovie, MoviesContext dbContext) =>
            {
                Movie movie = newMovie.ToEntity();

                dbContext.Add(movie);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(GetMovieById, new { id = movie.Id }, movie.ToMovieDetailsDto());
            });

            // PUT
            group.MapPut("/{id:int}", async (int id, UpdateMovieDto updMovie, MoviesContext dbContext) =>
            {
                var existingMovie = await dbContext.Movies.FindAsync(id);

                if (existingMovie is null)
                    return Results.NotFound();

                dbContext.Entry(existingMovie).CurrentValues.SetValues(updMovie.ToEntity(id));
                await dbContext.SaveChangesAsync();
                return Results.Ok(updMovie);
            });

            // Delete
            group.MapDelete("/{id:int}", async (int id, MoviesContext dbContext) =>
            {
                await dbContext.Movies.Where(m => m.Id == id).ExecuteDeleteAsync();
                return Results.NoContent();
            });

            return group;
        }
        
    }
}
