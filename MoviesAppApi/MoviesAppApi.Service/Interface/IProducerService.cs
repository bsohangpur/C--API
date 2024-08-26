using MoviesAppApi.Models.Request;
using MoviesAppApi.Models.Response;

namespace MoviesAppApi.Service.Interface
{
    public interface IProducerService
    {
        ProducerResponse Create(ProducerRequest producerRequest);
        bool Delete(int id);
        List<ProducerResponse> Get();
        ProducerResponse Get(int id);
        ProducerResponse Update(ProducerRequest producerRequest, int id);
    }
}