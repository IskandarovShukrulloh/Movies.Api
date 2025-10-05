using System.ComponentModel.DataAnnotations;

namespace Movies.Api.DTOs
{
    public class CreateMovieDto
    {
        [Required][StringLength(50)] public required string Title { get; set; }
        public int GenreId { get; set; }
        [Range(0, 10)] public decimal Rating { get; set; }
        public int ReleaseYear { get; set; }
    }
}
