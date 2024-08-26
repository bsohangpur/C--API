using Microsoft.Extensions.Options;
using MoviesAppApi.Domin.Models.DB;
using MoviesAppApi.Repository.Interface;

namespace MoviesAppApi.Repository
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(IOptions<ConnectionStrings> options)
            :base(options.Value)
        {
        }
        public IList<Producer> Get()
        {
            var query = @"SELECT [ID]
	                        ,[Name]
	                        ,[Bio]
	                        ,[DateOfBirth] AS [DOB]
	                        ,[Sex] AS [Gender]
                        FROM Foundation.Producers;";

            return Get(query);
        }
        public Producer Get(int id)
        {
            var query = @"SELECT [ID]
	                        ,[Name]
	                        ,[Bio]
	                        ,[DateOfBirth] AS [DOB]
	                        ,[Sex] AS [Gender]
                        FROM Foundation.Producers
                        WHERE ID = @Id;";

            return Get(query, id);
        }
        public int Create(Producer producer)
        {
            var query = @"INSERT INTO Foundation.Producers (
	                        Name
	                        ,Bio
	                        ,DateOfBirth
	                        ,Sex
	                        )
                        VALUES (
	                        @Name
	                        ,@Bio
	                        ,@DOB
	                        ,@Gender
	                        )
                        SELECT SCOPE_IDENTITY()";

            var value = new { producer.Name, producer.Bio, producer.DOB, producer.Gender };
            return Create(query, value);
        }
        public void Update(Producer producer, int id)
        {
            var query = @"UPDATE Foundation.Producers
                        SET
                        Name = @Name,
                        Bio = @Bio,
                        DateOfBirth = @DOB,
                        Sex = @Gender
                        WHERE ID = @Id";

            var value = new { Id = id, producer.Name, producer.Bio, producer.DOB, producer.Gender };
            Update(query, value);
        }
        public void Delete(int id)
        {
            var query = @"DELETE Foundation.MoviesActors
                        WHERE MovieId = (
		                        SELECT ID
		                        FROM Foundation.Movies
		                        WHERE ProducerId = @Id
		                        )

                        DELETE Foundation.Movies
                        WHERE ProducerId = @Id

                        DELETE Foundation.Producers
                        WHERE ID = @Id";

            Delete(query, id);
        }
    }
}
