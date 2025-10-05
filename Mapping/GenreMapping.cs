using Movies.Api.DTOs;
using Movies.Api.Entities;

namespace Movies.Api.Mapping;

public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre)
    {
        return new()
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }

    public static Genre ToEntity(this CreateGenreDto newGenre)
    {
        return new()
        {
            Name = newGenre.Name
        };
    }

    public static Genre ToEntity(this UpdateGenreDto updGenre, int id)
    {
        return new()
        {
            Id = id,
            Name = updGenre.Name
        };
    } 
}
