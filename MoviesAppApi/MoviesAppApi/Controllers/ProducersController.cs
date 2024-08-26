using Microsoft.AspNetCore.Mvc;
using MoviesAppApi.Models.Request;
using MoviesAppApi.Service;
using MoviesAppApi.Service.Interface;

namespace MoviesAppApi.Controllers
{
    [Route("/producers/")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var producers = _producerService.Get();
            if (producers.Count == 0)
                return NotFound();

            return Ok(producers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var producer = _producerService.Get(id);
            if (producer == null)
                return NotFound();

            return Ok(producer);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProducerRequest producerRequest)
        {
            var addProducer = _producerService.Create(producerRequest);
            return CreatedAtAction(nameof(GetAll), addProducer);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ProducerRequest producerRequest, int id)
        {
            var updetedProducer = _producerService.Update(producerRequest, id);
            if (updetedProducer == null)
                return NotFound();

            return Ok(updetedProducer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producerDelete = _producerService.Delete(id);
            if (producerDelete)
                return Ok("Producer has deleted successfully");

            return NotFound();
        }
    }
}
