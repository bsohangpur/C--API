using Microsoft.AspNetCore.Mvc;
using Firebase.Storage;
using MoviesAppApi.Models.Response;
using MoviesAppApi.Service.Interface;
using MoviesAppApi.Models.Request;

namespace MoviesAppApi.Controllers
{
    [Route("/movies/")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _movieService.Get();
            if (movies.Count == 0)
                return NotFound();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _movieService.Get(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MovieRequest movieRequest)
        {
            MovieResponse addMovie = _movieService.Create(movieRequest);
            if (addMovie == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetAll), addMovie);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] MovieRequest movieRequest, int id)
        {
            var updatedMovie = _movieService.Update(movieRequest, id);
            if (updatedMovie == null)
                return BadRequest();

            return Ok(updatedMovie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _movieService.Delete(id);
            if (movie)
                return Ok("Movie has deleted successfully");

            return NotFound();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");
            var task = await new FirebaseStorage("imbdapi.appspot.com")
                    .Child("CoverImage")
                    .Child(Guid.NewGuid().ToString() + ".jpg")
                    .PutAsync(file.OpenReadStream());
            return Ok(task);
        }

    }
}
