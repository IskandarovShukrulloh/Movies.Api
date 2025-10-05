using Microsoft.EntityFrameworkCore;
using Movies.Api.Data;
using Movies.Api.DTOs;
using Movies.Api.Entities;
using Movies.Api.Mapping;

namespace Movies.Api.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");
        const string GetGenreById = "GetGenre";

        // GET
        group.MapGet("/", async (MoviesContext dbContext) =>
                await dbContext.Genres
                                .Select(g => g.ToDto())
                                .AsNoTracking()
                                .ToListAsync()
        );

        // GET by ID
        group.MapGet("/{id:int}", async (int id, MoviesContext dbContext) =>
        {
            Genre? genre = await dbContext.Genres.FindAsync(id);

            return genre is null
                ? Results.NotFound()
                : Results.Ok(genre.ToDto());
        }).WithName(GetGenreById);
        
        // POST
        group.MapPost("/", async (CreateGenreDto newGenre, MoviesContext dbContext) =>
            {
                Genre genre = newGenre.ToEntity();

                dbContext.Add(genre);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(GetGenreById, new { id = genre.Id }, genre.ToDto());
            });
        // PUT
        group.MapPut("/{id:int}", async (int id, UpdateGenreDto updGenre, MoviesContext dbContext) =>
        {
            var existingGenre = await dbContext.Genres.FindAsync(id);

            if (existingGenre is null)
                return Results.NotFound();

            dbContext.Entry(existingGenre).CurrentValues.SetValues(updGenre.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.Ok(updGenre);
        });

        group.MapDelete("{id:int}", async (int id, MoviesContext dbContext) =>
        {
            await dbContext.Genres.Where(g => g.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}
