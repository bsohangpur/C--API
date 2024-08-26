using MoviesAppApi.Models.Request;
using MoviesAppApi.Models.Response;

namespace MoviesAppApi.Service.Interface
{
    public interface IActorService
    {
        ActorResponse Create(ActorRequest actorRequest);
        bool Delete(int id);
        List<ActorResponse> Get();
        ActorResponse Get(int id);
        ActorResponse Update(ActorRequest actorRequest, int id);
    }
}