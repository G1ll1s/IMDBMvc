using IMDBMvc.Services;
using IMDBMvc.Views.Movie;
using Microsoft.AspNetCore.Mvc;

namespace IMDBMvc.Controllers
{
    public class MovieController(
        DataService _dataService, 
        StateService _stateService
        ): Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Message"] = _stateService.Message;
            var model = _dataService.GetAllMovies();
            return View(model);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var model = _dataService.GetGenre();
            return View(model);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
            {
                _dataService.GetGenre();
                return View(model);
            }
            
            _dataService.AddMovie(model);

            _stateService.Message = "A Movie has been added!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var model = _dataService.GetMovie(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Search(string search)
        {
            var movies = _dataService.SearchMovies(search);
            return Json(movies);
        }

    }
}
