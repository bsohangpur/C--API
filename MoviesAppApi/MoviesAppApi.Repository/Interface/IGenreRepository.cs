using MoviesAppApi.Domin.Models.DB;

namespace MoviesAppApi.Repository.Interface
{
    public interface IGenreRepository
    {
        int Create(Genre genre);
        void Delete(int id);
        IList<Genre> Get();
        Genre Get(int id);
        IList<Genre> GetList(int id);
        void Update(Genre genre, int id);
    }
}