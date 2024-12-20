using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IMDBMvc.Views.Movie
{
    public class CreateVM
    {
        [Required(ErrorMessage ="Enter Title")]
        public string? Title { get; set; }
        public string? Description { get; set; } 

        public string? ImageUrl { get; set; } 

        [Range(1,10, ErrorMessage ="Must be a number between 1 and 10")]
        [Required(ErrorMessage ="Rating required")]
        [Display(Name ="Rating, Must be a number between 1 and 10")]
        public int Rating { get; set; }

        [Display(Name = "Genre")]
        public int SelectedGenreId { get; set; }

        public SelectListItem[]? Genres { get; set; }

    }
}
