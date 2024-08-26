using Microsoft.Extensions.Options;
using MoviesAppApi.Domin.Models.DB;
using MoviesAppApi.Models.Request;
using MoviesAppApi.Models.Response;
using MoviesAppApi.Repository;
using MoviesAppApi.Repository.Interface;
using MoviesAppApi.Service.Interface;

namespace MoviesAppApi.Service
{
    public class MovieService : BaseRepository<int>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IReviewRepository _reviewRepository;
        public MovieService(IOptions<ConnectionStrings> options, 
            IMovieRepository movieRepository, IProducerRepository producerRepository,
            IActorRepository actorRepository, IGenreRepository genreRepository
            , IReviewRepository reviewRepository)
            : base(options.Value)
        {
            _movieRepository = movieRepository;
            _producerRepository = producerRepository;
            _actorRepository = actorRepository;
            _genreRepository = genreRepository;
            _reviewRepository = reviewRepository;
        }
        public List<MovieResponse> Get()
        {
            IList<Movie> movies = _movieRepository.Get();

            var response = movies.Select(value => new MovieResponse()
            {
                Id = value.Id,
                Name = value.Name,
                YearOfRelease = value.YearOfRelease,
                Plot = value.Plot,
                Producer = _producerRepository.Get(value.ProducerId),
                CoverImage = value.CoverImage,
                CreatedAt = value.CreatedAt,
                UpdatedAt = value.UpdatedAt,
                Language = value.Language,
                Profit = value.Profit,
                Actors = _actorRepository.GetList(value.Id),
                Genres = _genreRepository.GetList(value.Id),
                Reviews = _reviewRepository.Get(value.Id)
            }).ToList();         

            return response;
        }
        public MovieResponse Get(int id)
        {
            var movie = _movieRepository.Get(id);
            if (movie == null)
                return null;

            return new MovieResponse()
            {
                Id = movie.Id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Producer = _producerRepository.Get(movie.ProducerId),
                CoverImage = movie.CoverImage,
                CreatedAt = movie.CreatedAt,
                UpdatedAt = movie.UpdatedAt,
                Language = movie.Language,
                Profit = movie.Profit,
                Actors = _actorRepository.GetList(id),
                Genres = _genreRepository.GetList(id),
                Reviews = _reviewRepository.Get(movie.Id)
            };
        }
        public MovieResponse Create(MovieRequest movieRequest)
        {
            var movie = new Movie()
            {
                Name = movieRequest.Name,
                YearOfRelease = movieRequest.YearOfRelease,
                Plot = movieRequest.Plot,
                ProducerId = movieRequest.ProducerId,
                CoverImage = movieRequest.CoverImage,
                Language = movieRequest.Language,
                Profit = movieRequest.Profit,
                ActorIds = movieRequest.ActorIds,
                GenreIds = movieRequest.GenreIds,
            };

            var id = _movieRepository.Create(movie);
            var newMovie = _movieRepository.Get(id);

            return new MovieResponse()
            {
                Id = id,
                Name = newMovie.Name,
                YearOfRelease = newMovie.YearOfRelease,
                Plot = newMovie.Plot,
                Producer = _producerRepository.Get(newMovie.ProducerId),
                CoverImage = newMovie.CoverImage,
                CreatedAt = newMovie.CreatedAt,
                UpdatedAt = newMovie.UpdatedAt,
                Language = newMovie.Language,
                Profit = newMovie.Profit,
                Actors = _actorRepository.GetList(id),
                Genres = _genreRepository.GetList(id)
            };
        }
        public MovieResponse Update(MovieRequest movieRequest, int id)
        {
            var movie = _movieRepository.Get(id);
            if (movie == null)
                return null;

            movie.Id = movieRequest.Id;
            movie.Name = movieRequest.Name;
            movie.YearOfRelease = movieRequest.YearOfRelease;
            movie.Plot = movieRequest.Plot;
            movie.ProducerId = movieRequest.ProducerId;
            movie.CoverImage = movieRequest.CoverImage;
            movie.ActorIds = movieRequest.ActorIds;
            movie.GenreIds = movieRequest.GenreIds;

            _movieRepository.Update(movie, id);

            return new MovieResponse()
            {
                Id = id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Producer = _producerRepository.Get(movie.ProducerId),
                CoverImage = movie.CoverImage,
                CreatedAt = movie.CreatedAt,
                UpdatedAt = movie.UpdatedAt,
                Language = movie.Language,
                Profit = movie.Profit,
                Actors = _actorRepository.GetList(id),
                Genres = _genreRepository.GetList(id),
            };
        }
        public bool Delete(int id)
        {
            var movie = _movieRepository.Get(id);
            if (movie == null)
                return false;

            _movieRepository.Delete(id);
            return true;
        }
    }
}
