using MoviesAppApi.Domin.Models.DB;
using MoviesAppApi.Models.Request;
using MoviesAppApi.Models.Response;
using MoviesAppApi.Repository.Interface;
using MoviesAppApi.Service.Interface;

namespace MoviesAppApi.Service
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public List<GenreResponse> Get()
        {
            IList<Genre> genres = _genreRepository.Get();

            var respose = genres.Select(response => new GenreResponse()
            {
                Id = response.Id,
                Name = response.Name,
            }).ToList();

            return respose;
        }
        public GenreResponse Get(int id)
        {
            var genre = _genreRepository.Get(id);
            if (genre == null)
                return null;

            return new GenreResponse()
            {
                Id = genre.Id,
                Name = genre.Name,
            };
        }
        public GenreResponse Create(GenreRequest genreRequest)
        {
            var genre = new Genre()
            {
                Name = genreRequest.Name
            };

            var id = _genreRepository.Create(genre);

            return new GenreResponse()
            {
                Id = id,
                Name = genre.Name,
            };
        }
        public GenreResponse Update(GenreRequest genreRequest, int id)
        {
            var genre = _genreRepository.Get(id);
            if (genre == null)
                return null;

            genre.Id = genreRequest.Id;
            genre.Name = genreRequest.Name;

            _genreRepository.Update(genre, id);

            return new GenreResponse()
            {
                Id = id,
                Name = genre.Name,
            };
        }
        public bool Delete(int id)
        {
            var genre = _genreRepository.Get(id);
            if(genre == null) 
                return false;

            _genreRepository.Delete(id);
            return true;
        }
    }
}
