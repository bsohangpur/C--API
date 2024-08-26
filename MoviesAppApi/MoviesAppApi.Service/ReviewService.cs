using MoviesAppApi.Domin.Models.DB;
using MoviesAppApi.Models.Request;
using MoviesAppApi.Models.Response;
using MoviesAppApi.Repository.Interface;
using MoviesAppApi.Service.Interface;

namespace MoviesAppApi.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieService _movieService;
        public ReviewService(IReviewRepository reviewRepository, IMovieService movieService)
        {
            _reviewRepository = reviewRepository;
            _movieService = movieService;
        }
        public List<ReviewResponse> Get(int MovieId)
        {
            IList<Review> reviews = _reviewRepository.Get(MovieId);

            var respose = reviews.Select(response => new ReviewResponse()
            {
                Id = response.Id,
                Message = response.Message,
                Movie = _movieService.Get(response.MovieId)
            }).ToList();

            return respose;
        }
        public ReviewResponse GetById(int id)
        {
            var review = _reviewRepository.GetById(id);
            if (review == null)
                return null;

            return new ReviewResponse()
            {
                Id = review.Id,
                Message = review.Message,
                Movie = _movieService.Get(review.MovieId)
            };
        }
        public ReviewResponse Create(ReviewRequest reviewRequest, int movieId)
        {
            var review = new Review()
            {
                Message = reviewRequest.Message,
                MovieId = movieId
            };

            var id =_reviewRepository.Create(review);

             var responce = new ReviewResponse()
            {
                Id = id,
                Message = review.Message,
                Movie = _movieService.Get(review.MovieId)
            };
            return responce;
        }
        public ReviewResponse Update(ReviewRequest reviewRequest, int movieId, int id)
        {
            var review = _reviewRepository.GetById(id);
            if (review == null)
                return null;

            review.Message = reviewRequest.Message;
            review.MovieId = movieId;

            _reviewRepository.Update(review, id);

            return new ReviewResponse()
            {
                Id = review.Id,
                Message = review.Message,
                Movie = _movieService.Get(review.MovieId)
            };
        }
        public bool Delete(int id, int MovieId)
        {
            var review = _reviewRepository.GetById(id);
            if(review == null)
                return false;

            _reviewRepository.Delete(id);
            return true;
        }
    }
}

