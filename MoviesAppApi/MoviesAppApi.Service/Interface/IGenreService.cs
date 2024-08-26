using MoviesAppApi.Models.Request;
using MoviesAppApi.Models.Response;

namespace MoviesAppApi.Service.Interface
{
    public interface IGenreService
    {
        GenreResponse Create(GenreRequest genreRequest);
        bool Delete(int id);
        List<GenreResponse> Get();
        GenreResponse Get(int id);
        GenreResponse Update(GenreRequest genreRequest, int id);
    }
}