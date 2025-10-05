namespace Movies.Api.DTOs
{
    public class MovieSummaryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public decimal? Rating { get; set; }
        public int ReleaseYear { get; set; }
    }
}
