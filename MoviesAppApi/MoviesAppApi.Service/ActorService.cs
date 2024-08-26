using MoviesAppApi.Domin.Models.DB;
using MoviesAppApi.Models.Request;
using MoviesAppApi.Models.Response;
using MoviesAppApi.Repository.Interface;
using MoviesAppApi.Service.Interface;

namespace MoviesAppApi.Service
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public List<ActorResponse> Get()
        {
            IList<Actor> actors = _actorRepository.Get();
            var respose = actors.Select(response => new ActorResponse()
            {
                Id = response.Id,
                Name = response.Name,
                Gender = response.Gender,
                Bio = response.Bio,
                DOB = response.DOB
            }).ToList();

            return respose;
        }
        public ActorResponse Get(int id)
        {
            var actor = _actorRepository.Get(id);
            if (actor == null)
                return null;

            return new ActorResponse()
            {
                Id = actor.Id,
                Name = actor.Name,
                Gender = actor.Gender,
                Bio = actor.Bio,
                DOB = actor.DOB
            };
        }
        public ActorResponse Create(ActorRequest actorRequest)
        {
            var actor = new Actor()
            {
                Name = actorRequest.Name,
                Gender = actorRequest.Gender,
                Bio = actorRequest.Bio,
                DOB = actorRequest.DOB
            };

            var id = _actorRepository.Create(actor);

            return new ActorResponse()
            {
                Id = id,
                Name = actor.Name,
                Gender = actor.Gender,
                Bio = actor.Bio,
                DOB = actor.DOB
            };
        }
        public ActorResponse Update(ActorRequest actorRequest, int id)
        {
            var actor = _actorRepository.Get(id);
            if (actor == null)
                return null;

            actor.Id = actorRequest.Id;
            actor.Name = actorRequest.Name;
            actor.Gender = actorRequest.Gender;
            actor.Bio = actorRequest.Bio;
            actor.DOB = actorRequest.DOB;

            _actorRepository.Update(actor, id);

            return new ActorResponse()
            {
                Id = id,
                Name = actor.Name,
                Gender = actor.Gender,
                Bio = actor.Bio,
                DOB = actor.DOB
            };
        }
        public bool Delete(int id)
        {
            var actor = _actorRepository.Get(id);
            if (actor == null)
                return false;

            _actorRepository.Delete(id);
            return true;
        }
    }
}
