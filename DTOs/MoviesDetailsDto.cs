namespace Movies.Api.DTOs;

public class MoviesDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int GenreId { get; set; }
    public decimal? Rating { get; set; }
    public int ReleaseYear { get; set; }
}
