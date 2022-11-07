using System.Threading.Tasks;
using System.Web.Http;
using GulaylarCase.Business.Abstract;
using GulaylarCase.Data.ViewModel;

namespace GulaylarCase.WebApi.Controllers
{
    [RoutePrefix("api/v1/Users/{userId}/Subscribes")]
    public class SubscribesController : ApiController
    {
        private ISubscribeService _repository;
        public SubscribesController(ISubscribeService repository)
        {
            _repository = repository;
        }
        // GET: api/Subscribes
        [HttpGet]
        [Route("")]
        public async Task<ServiceResponse<SubscribeDto>> GetAll(int userId)
        {
          return _repository.GetList(userId);
        }

        // GET: api/Subscribes/5
        [Route("{id}")]
        public async Task<ServiceResponse<SubscribeDto>> Get(int id, int userId)
        {
            return _repository.GetById(id, userId);
        }

        // POST: api/Subscribes
        [Route("")]
        [HttpPost]
        public async Task<ServiceResponse<SubscribeDto>> Post(int userId, SubscribeDto model)
        {
            return   _repository.Insert(userId, model);
        }

        // PUT: api/Subscribes/5
        [Route("{id}")]
        public async Task<ServiceResponse<SubscribeDto>> Put(int id, int userId, SubscribeDto model)
        {
            return   _repository.Update(id, userId, model);
        }

        // DELETE: api/Subscribes/5
        [Route("{id}")]
        public async Task<ServiceResponse<SubscribeDto>> Delete(int id, int userId)
        {
            return   _repository.Delete(id, userId);
        }
    }
}
