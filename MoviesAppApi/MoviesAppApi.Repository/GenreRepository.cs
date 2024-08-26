using Microsoft.Extensions.Options;
using MoviesAppApi.Domin.Models.DB;
using MoviesAppApi.Repository.Interface;

namespace MoviesAppApi.Repository
{

    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IOptions<ConnectionStrings> options)
            :base(options.Value)
        {
        }
        public IList<Genre> Get()
        {
            var query = @"SELECT [ID]
	                        ,[Name]
                        FROM Foundation.Genres";

            return Get(query);
        }
        public Genre Get(int id)
        {
            var query = @"SELECT [ID]
	                        ,[Name]
                        FROM Foundation.Genres
                        WHERE [ID] = @Id";

            return Get(query, id);
        }
        public IList<Genre> GetList(int id) {
            var query = @"SELECT [G].[ID]
	                        ,[G].[Name]
                        FROM Foundation.Movies M
                        JOIN Foundation.GenresMovies MG ON M.ID = MG.MovieID
                        JOIN Foundation.Genres G ON G.ID = MG.GenreId
                        WHERE M.ID = @Id";

            return GetList(query, id);
        }
        public int Create(Genre genre)
        {
            var query = @"INSERT INTO Foundation.Genres (Name)
                        VALUES (@Name)
                        SELECT SCOPE_IDENTITY()";

            var value = new { genre.Name };
            return Create(query, value);
        }
        public void Update(Genre genre, int id)
        {
            var query = @"UPDATE Foundation.Genres
                        SET
                        Name = @Name
                        WHERE ID = @Id";

            var value = new { Id= id, genre.Name };
            Update(query, value);
        }
        public void Delete(int id)
        {
            var query = @"DELETE Foundation.GenresMovies
                        WHERE GenreId = @Id
                        DELETE Foundation.Genres
                        WHERE ID = @Id";

            Delete(query, id);
        }
    }
}
