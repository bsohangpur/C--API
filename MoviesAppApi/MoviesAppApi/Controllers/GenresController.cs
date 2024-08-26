using Microsoft.AspNetCore.Mvc;
using MoviesAppApi.Service.Interface;
using MoviesAppApi.Models.Request;

namespace MoviesAppApi.Controllers
{
    [Route("/genres/")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var genres = _genreService.Get();
            if (genres.Count == 0)
                return NotFound();

            return Ok(genres);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var genre = _genreService.Get(id);
            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        [HttpPost]
        public IActionResult Create([FromBody] GenreRequest genreRequest)
        {
            var addGenre = _genreService.Create(genreRequest);
            return CreatedAtAction(nameof(GetAll), addGenre);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] GenreRequest genreRequest, int id)
        {
            var updatedGenre = _genreService.Update(genreRequest, id);
            if(updatedGenre == null)
                return NotFound();

            return Ok(updatedGenre);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedGenre = _genreService.Delete(id);
            if (deletedGenre)
                return Ok("Genre has deleted successfully");

            return NotFound();
        }
    }
}
