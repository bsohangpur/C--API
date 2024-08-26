using MoviesAppApi.Domin.Models.DB;

namespace MoviesAppApi.Repository.Interface
{
    public interface IActorRepository
    {
        int Create(Actor actor);
        void Delete(int id);
        IList<Actor> Get();
        Actor Get(int id);
        IList<Actor> GetList(int id);
        void Update(Actor actor, int id);
    }
}