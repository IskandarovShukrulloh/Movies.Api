using Movies.Api.DTOs;
using Movies.Api.Entities;

namespace Movies.Api.Mapping;

public static class MovieMapping
{
    public static Movie ToEntity(this CreateMovieDto movieDto)
    {
        return new()
        {
            Title = movieDto.Title,
            GenreId = movieDto.GenreId,
            Rating = movieDto.Rating,
            ReleaseYear = movieDto.ReleaseYear
        };
    }

    public static MovieSummaryDto ToMovieSummaryDto(this Movie movie)
    {
        return new MovieSummaryDto()
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre!.Name, /* Name - we need string; ! - if sure won't be null */
            Rating = movie.Rating,
            ReleaseYear = movie.ReleaseYear
        };
    }

    public static MoviesDetailsDto ToMovieDetailsDto(this Movie movie)
    {
        return new()
        {
            Id = movie.Id,
            Title = movie.Title,
            GenreId = movie.GenreId, /* Name - we need string; ! - if sure won't be null */
            Rating = movie.Rating,
            ReleaseYear = movie.ReleaseYear
        };
    }

    public static Movie ToEntity(this UpdateMovieDto updMovie, int id)
    {
        return new()
        {
            Id = id,
            Title = updMovie.Title,
            GenreId = updMovie.GenreId,
            Rating = updMovie.Rating,
            ReleaseYear = updMovie.ReleaseYear
        };
    } 
}
