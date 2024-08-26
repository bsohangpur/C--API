using Microsoft.AspNetCore.Mvc;
using MoviesAppApi.Models.Request;
using MoviesAppApi.Service.Interface;

namespace MoviesAppApi.Controllers
{
    [Route("/actors/")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var actors = _actorService.Get();
            if(actors.Count == 0)
                return NotFound();

            return Ok(actors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var actor = _actorService.Get(id);
            if (actor == null)
                return NotFound();
            return Ok(actor);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActorRequest actor)
        {
            var addActor = _actorService.Create(actor);
            return CreatedAtAction(nameof(GetAll), addActor);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ActorRequest actor, int id)
        {
            var updatedActor = _actorService.Update(actor, id);
            if(updatedActor == null)
                return NotFound();

            return Ok(updatedActor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var actor = _actorService.Delete(id);
            if(actor)
                return Ok("Actor has deleted successfully");
            
            return NotFound();
        }
    }
}
