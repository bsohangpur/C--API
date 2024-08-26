using Dapper;
using Microsoft.Data.SqlClient;
using MoviesAppApi.Domin.Models.DB;

namespace MoviesAppApi.Repository
{
    public class BaseRepository<T>
    {
        private readonly string _connectionStrings;
        public BaseRepository(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings.Database;
        }
        public IList<T> Get(string query)
        {
            using var connection = new SqlConnection(_connectionStrings);
            return connection.Query<T>(query).ToList();
        }
        public T Get(string query, int id)
        {
            using var connection = new SqlConnection(_connectionStrings);
            return connection.QueryFirstOrDefault<T>(query, new { Id = id });
        }
        public IList<T> GetList(string query, int id)
        {
            using var connection = new SqlConnection(_connectionStrings);
            return connection.Query<T>(query, new { Id = id }).ToList();
        }
        public int Create(string query, object value)
        {
            using var connection = new SqlConnection(_connectionStrings);
            return connection.QuerySingleOrDefault<int>(query, value);
        }
        public void Update(string query, object value)
        {
            using var connection = new SqlConnection(_connectionStrings);
            connection.Execute(query, value);
        }
        public void Delete(string query, int id)
        {
            using var connection = new SqlConnection(_connectionStrings);
            connection.Execute(query, new { Id = id});
        }
    }
}
