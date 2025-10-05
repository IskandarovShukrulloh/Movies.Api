namespace Movies.Api.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public decimal? Rating { get; set; }
        public int ReleaseYear { get; set; } = 0;
    }
}
