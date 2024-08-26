using MoviesAppApi.Models.Request;
using MoviesAppApi.Models.Response;

namespace MoviesAppApi.Service.Interface
{
    public interface IMovieService
    {
        MovieResponse Create(MovieRequest movieRequest);
        bool Delete(int id);
        List<MovieResponse> Get();
        MovieResponse Get(int id);
        MovieResponse Update(MovieRequest movieRequest, int id);
    }
}