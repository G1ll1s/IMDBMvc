namespace IMDBMvc.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Rating { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}
