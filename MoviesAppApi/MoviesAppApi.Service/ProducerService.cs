using MoviesAppApi.Domin.Models.DB;
using MoviesAppApi.Models.Request;
using MoviesAppApi.Models.Response;
using MoviesAppApi.Repository.Interface;
using MoviesAppApi.Service.Interface;

namespace MoviesAppApi.Service
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerService(IProducerRepository ProducerRepository)
        {
            _producerRepository = ProducerRepository;
        }
        public List<ProducerResponse> Get()
        {
            IList<Producer> producer = _producerRepository.Get();

            var respose = producer.Select(response => new ProducerResponse()
            {
                Id = response.Id,
                Name = response.Name,
                Gender = response.Gender,
                Bio = response.Bio,
                DOB = response.DOB
            }).ToList();

            return respose;
        }
        public ProducerResponse Get(int id)
        {
            var producer = _producerRepository.Get(id);
            if (producer == null)
                return null;

            return new ProducerResponse()
            {
                Id = producer.Id,
                Name = producer.Name,
                Gender = producer.Gender,
                Bio = producer.Bio,
                DOB = producer.DOB
            };
        }
        public ProducerResponse Create(ProducerRequest producerRequest)
        {
            var producer = new Producer()
            {
                Id = producerRequest.Id,
                Name = producerRequest.Name,
                Gender = producerRequest.Gender,
                Bio = producerRequest.Bio,
                DOB = producerRequest.DOB
            };

            var id = _producerRepository.Create(producer);

            return new ProducerResponse()
            {
                Id = id,
                Name = producer.Name,
                Gender = producer.Gender,
                Bio = producer.Bio,
                DOB = producer.DOB
            };
        }
        public ProducerResponse Update(ProducerRequest producerRequest, int id)
        {
            var producer = _producerRepository.Get(id);
            if (producer == null)
                return null;

            producer.Id = producerRequest.Id;
            producer.Name = producerRequest.Name;
            producer.Gender = producerRequest.Gender;
            producer.Bio = producerRequest.Bio;
            producer.DOB = producerRequest.DOB;

            _producerRepository.Update(producer, id);

            return new ProducerResponse()
            {
                Id = id,
                Name = producer.Name,
                Gender = producer.Gender,
                Bio = producer.Bio,
                DOB = producer.DOB
            };
        }
        public bool Delete(int id)
        {
            var producer = _producerRepository.Get(id);
            if (producer == null)
                return false;

            _producerRepository.Delete(id);
            return true;
        }
    }
}
