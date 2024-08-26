using MoviesAppApi.Models.Request;
using MoviesAppApi.Models.Response;

namespace MoviesAppApi.Service.Interface
{
    public interface IReviewService
    {
        ReviewResponse Create(ReviewRequest reviewRequest, int movieId);
        bool Delete(int id, int MovieId);
        List<ReviewResponse> Get(int MovieId);
        ReviewResponse GetById(int id);
        ReviewResponse Update(ReviewRequest reviewRequest, int movieId, int id);
    }
}