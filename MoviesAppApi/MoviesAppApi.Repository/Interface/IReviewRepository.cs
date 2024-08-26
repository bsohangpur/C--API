using MoviesAppApi.Domin.Models.DB;

namespace MoviesAppApi.Repository.Interface
{
    public interface IReviewRepository
    {
        int Create(Review review);
        void Delete(int id);
        IList<Review> Get(int MovieId);
        Review GetById(int id);
        void Update(Review review, int id);
    }
}