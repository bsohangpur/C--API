

using MoviesAppApi.Domin.Models.DB;

namespace MoviesAppApi.Repository.Interface
{
    public interface IMovieRepository
    {
        int Create(Movie movie);
        void Delete(int id);
        IList<Movie> Get();
        Movie Get(int id);
        void Update(Movie movie, int id);
    }
}