using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MovieApp.Models;
using MovieApp.Repositories;


namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return movie != null ? Ok(movie) : NotFound();
        }

        [HttpGet("genre/{genre}")]
        public async Task<IActionResult> GetMoviesByGenre(string genre)
        {
            var movies = await _movieRepository.GetMoviesByGenreAsync(genre);
            return Ok(movies);
        }

        // Additional actions for Create, Update, and Delete can be added similarly.
    }
}