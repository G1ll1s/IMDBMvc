namespace IMDBMvc.Views.Movie
{
    public class IndexVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Rating { get; set; }

        public string? SearchQuery { get; set; }
        public MovieVM[] Movies { get; set; } = null!;

        public class MovieVM
        {
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? ImageUrl { get; set; } 
            public int Rating { get; set; }
            public string? Genre { get; set; }
        }
    }
}
