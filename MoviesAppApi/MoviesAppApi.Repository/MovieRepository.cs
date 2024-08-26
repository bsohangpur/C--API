using Microsoft.Extensions.Options;
using MoviesAppApi.Domin.Models.DB;
using MoviesAppApi.Repository.Interface;

namespace MoviesAppApi.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IOptions<ConnectionStrings> options)
            : base(options.Value)
        {
        }
        public IList<Movie> Get()
        {
            var query = @"SELECT [ID]
                            ,[Name]
	                        ,[YearOfRelease]
	                        ,[Plot]
	                        ,[ProducerId]
	                        ,[Poster] AS [CoverImage]
                            ,[CreatedAt]
                            ,[UpdatedAt]
	                        ,[Language]
                            ,[Profit]
                        FROM Foundation.Movies";

            return Get(query);
        }
        public Movie Get(int id)
        {
            var query = @"SELECT  [ID]
                            ,[Name]
	                        ,[YearOfRelease]
	                        ,[Plot]
	                        ,[ProducerId]
	                        ,[Poster] AS [CoverImage]
                            ,[CreatedAt]
                            ,[UpdatedAt]
	                        ,[Language]
                            ,[Profit]
                        FROM Foundation.Movies
                        WHERE ID = @Id";

            return Get(query, id);
        }
        public int Create(Movie movie)
        {
            var query = @"EXEC [dbo].[usp_AddMovie]
	                    @Name
	                    ,@YearOfRelease
	                    ,@Plot
	                    ,@ProducerId
	                    ,@Poster
	                    ,@CreatedAt
	                    ,@UpdatedAt
	                    ,@Language 
	                    ,@Profit
                        ,@ActorIds
                        ,@GenreIds
	                    ";
            var actorIds = movie.ActorIds.Select(id=>id.ToString()).ToList();
            var genresIds = movie.GenreIds.Select(id=>id.ToString()).ToList();
            var value = new
            {
                movie.Name,
                movie.YearOfRelease,
                movie.Plot,
                movie.ProducerId,
                Poster = movie.CoverImage,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                movie.Language,
                movie.Profit,
                ActorIds = String.Join(",",actorIds),
                GenreIds = String.Join(",", genresIds),
            };
            return Create(query, value);
        }
        public void Update(Movie movie, int id)
        {
            var query = @"EXEC [dbo].[usp_UpdateMovie]
                        @Id
                        ,@Name
	                    ,@YearOfRelease
	                    ,@Plot
	                    ,@ProducerId
	                    ,@Poster
	                    ,@UpdatedAt
	                    ,@Language 
	                    ,@Profit
                        ,@ActorIds
                        ,@GenreIds";

            var actorIds = movie.ActorIds.Select(id => id.ToString()).ToList();
            var genresIds = movie.GenreIds.Select(id => id.ToString()).ToList();
            var value = new
            {
                Id = id,
                movie.Name,
                movie.YearOfRelease,
                movie.Plot,
                movie.ProducerId,
                Poster = movie.CoverImage,
                UpdatedAt = DateTime.Now,
                movie.Language,
                movie.Profit,
                ActorIds = String.Join(",", actorIds),
                GenreIds = String.Join(",", genresIds),
            };
            Update(query, value);
        }
        public void Delete(int id)
        {
            var query = @"[dbo].[usp_DeleteMovie] @Id";
            Delete(query, id);
        }
    }
}
