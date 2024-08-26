using Microsoft.Extensions.Options;
using MoviesAppApi.Domin.Models.DB;
using MoviesAppApi.Repository.Interface;

namespace MoviesAppApi.Repository
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(IOptions<ConnectionStrings> options)
            : base(options.Value)
        {
        }
        public IList<Review> Get(int MovieId)
        {
            var query = @"SELECT [ID]
	                        ,[Message]
	                        ,[MovieId]
                        FROM Foundation.Reviews
                        WHERE [MovieId] = @Id";
            return GetList(query, MovieId);
        }
        public Review GetById(int id)
        {
            var query = @"SELECT [ID]
	                        ,[Message]
	                        ,[MovieId]
                        FROM Foundation.Reviews
                        WHERE ID = @Id";

            return Get(query, id);
        }
        public int Create(Review review)
        {
            var query = @"INSERT INTO Foundation.Reviews (
	                        Message
	                        ,MovieId
	                        )
                        VALUES (
	                        @Message
	                        ,@MovieId
	                        )
                        SELECT SCOPE_IDENTITY()";

            var value = new {review.Message, review.MovieId};
            return Create(query, value);
        }
        public void Update(Review review, int id)
        {
            var query = @"UPDATE Foundation.Reviews
                        SET Message = @Message
                        WHERE ID = @Id";

            var value = new {Id = id, review.Message};
            Update(query, value);
        }
        public void Delete(int id)
        {
            var query = @"DELETE Foundation.Reviews
                        WHERE ID = @Id";

            Delete(query, id);
        }
    }
}
