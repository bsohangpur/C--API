using Microsoft.Extensions.Options;
using MoviesAppApi.Domin.Models.DB;
using MoviesAppApi.Repository.Interface;

namespace MoviesAppApi.Repository
{

    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(IOptions<ConnectionStrings> options)
            : base(options.Value)
        {
        }
        public IList<Actor> Get()
        {
            var query = @"SELECT [ID]
	                        ,[Name]
	                        ,[Bio]
	                        ,[DateOfBirth] AS [DOB]
	                        ,[Sex] AS [Gender]
                        FROM Foundation.Actors;";

            return Get(query);
        }
        public Actor Get(int id)
        {
            var query = @"SELECT [ID]
	                        ,[Name]
	                        ,[Bio]
	                        ,[DateOfBirth] AS [DOB]
	                        ,[Sex] AS [Gender]
                        FROM Foundation.Actors
                        WHERE [ID] = @Id;";

            return Get(query, id);
        }
        public IList<Actor> GetList(int id)
        {
            var query = @"SELECT [A].[ID], [A].[Name]
	                        ,[A].[Bio]
	                        ,[A].[DateOfBirth] AS [DOB]
	                        ,[A].[Sex] AS [Gender]
                        FROM Foundation.Movies M
                        JOIN Foundation.MoviesActors MA ON M.ID = MA.MovieID
                        JOIN Foundation.Actors A ON A.ID = MA.ActorID
                        WHERE M.ID = @Id";

            return GetList(query, id);
        }
        public int Create(Actor actor)
        {
            var query = @"INSERT INTO Foundation.Actors (
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

            var value = new { actor.Name, actor.Bio, actor.DOB, actor.Gender };
            return Create(query, value);
        }
        public void Update(Actor actor, int id)
        {
            var query = @"UPDATE Foundation.Actors
                        SET Name = @Name
	                        ,Bio = @Bio
	                        ,DateOfBirth = @DOB
	                        ,Sex = @Gender
                        WHERE ID = @Id";

            var value = new { Id =id, actor.Name, actor.Bio, actor.DOB, actor.Gender };
            Update(query,value);
        }
        public void Delete(int id)
        {
            var query = @"DELETE Foundation.MoviesActors
                        WHERE ActorID = @Id
                        DELETE Foundation.Actors
                        WHERE ID = @Id";

            Delete(query, id);
        }
    }
}
