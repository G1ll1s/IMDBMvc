namespace IMDBMvc.Views.Movie
{
    public class DetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Rating { get; set; }
        public string Genre { get; set; } = null!;
    }
}
