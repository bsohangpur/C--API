using Microsoft.AspNetCore.Mvc;
using MoviesAppApi.Models.Request;
using MoviesAppApi.Service.Interface;

namespace MoviesAppApi.Controllers
{
    [Route("/movies/{movieId}/reviews/")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        public IActionResult GetAll(int MovieId)
        {
            var reviews = _reviewService.Get(MovieId);
            if(reviews.Count == 0)
                return NotFound();

            return Ok(reviews);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id, int MovieId)
        {
            var review = _reviewService.GetById(id);
            if(review == null)
                return NotFound();

            return Ok(review);
        }
        [HttpPost]
        public IActionResult Create([FromBody] ReviewRequest reviewRequest,int movieId)
        {
            var addReview = _reviewService.Create(reviewRequest,movieId);
            if (addReview == null)
                return BadRequest();
            return Created(nameof(GetAll), addReview);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ReviewRequest reviewRequest,int movieId, int id)
        {
            var updetedReview = _reviewService.Update(reviewRequest, movieId, id);
            if (updetedReview == null)
                return NotFound();

            return Ok(updetedReview);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, int MovieId)
        {
            var deletedReview = _reviewService.Delete(id, MovieId);
            if(deletedReview)
                return Ok("Review has deleted successfully");

            return NotFound();
        }
    }
}
