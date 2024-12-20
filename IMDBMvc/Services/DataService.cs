using IMDBMvc.Models;
using IMDBMvc.Views.Movie;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMDBMvc.Services
{
    public class DataService(ApplicationContext _context)
    {
        public IndexVM GetMovieById(int id)
        {
            var movie = _context.Movies
                .Where(m => m.Id == id)
                .Select(m => new IndexVM()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Rating = m.Rating
                })
                .SingleOrDefault();
            return movie!;
        }

        public IndexVM GetAllMovies()
        {
            var ret = new IndexVM()
            {
                Movies = _context.Movies
                .Select(m => new IndexVM.MovieVM()
                {
                    Id = m.Id,
                    Title = m.Title,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m.Genre.GenreName
                })
                .OrderBy(m => m.Title)
                .ToArray()
            };

            return ret;
        }

        public void AddMovie(CreateVM model)
        {
            _context.Movies.Add(new Movie
            {
                Title = model.Title ?? string.Empty,
                Description = model.Description ?? string.Empty,
                ImageUrl = model.ImageUrl ?? string.Empty,
                Rating = model.Rating,
                GenreId = model.SelectedGenreId
            });
            _context.SaveChanges();
        }

        public DetailsVM? GetMovie(int id)
        {
            var movie = _context.Movies
                .Where(m => m.Id == id)
                .Select(m => new DetailsVM()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m.Genre.GenreName
                })
                .SingleOrDefault();
            return movie;
        }

        public IndexVM.MovieVM[] SearchMovies(string search)
        {
            return _context.Movies
                .Where(m => m.Title.Contains(search))
                .Select(m => new IndexVM.MovieVM()
                {
                    Id = m.Id,
                    Title = m.Title,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m.Genre.GenreName
                })
                .ToArray();
        }

        //Hjälpmetod för att hämta Genres till en dropdown lista
        public CreateVM GetGenre()
        {
            return new CreateVM()
            {
                Genres = _context.Genres
                .Select(g => new SelectListItem()
                {
                    Value = g.Id.ToString(),
                    Text = g.GenreName
                })
                .ToArray()
            };
        }


    }
}
