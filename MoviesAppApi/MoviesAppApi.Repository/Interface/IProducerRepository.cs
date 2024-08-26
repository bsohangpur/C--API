using MoviesAppApi.Domin.Models.DB;

namespace MoviesAppApi.Repository.Interface
{
    public interface IProducerRepository
    {
        int Create(Producer producer);
        void Delete(int id);
        IList<Producer> Get();
        Producer Get(int id);
        void Update(Producer producer, int id);
    }
}