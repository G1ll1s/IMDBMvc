namespace IMDBMvc.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; } = null!;
        public List<Movie> Movies { get; set; } = null!;
    }
}
