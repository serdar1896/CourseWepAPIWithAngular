using System;
using System.Threading.Tasks;
using System.Web.Http;
using GulaylarCase.Business.Abstract;
using GulaylarCase.Data.ViewModel;

namespace GulaylarCase.WebApi.Controllers
{
    [Route("api/v1/Users/{userId}/WatchHistorys")]
    public class WatchHistorysController : ApiController
    {
        private IWatchHistoryService _repository;
        public WatchHistorysController(IWatchHistoryService repository)
        {
            _repository = repository;
        }
        // GET: api/api/v1/Users/{userId}/WatchHistorys
        [HttpGet]
        [Route("api/v1/Users/{userId}/WatchHistorys")]
        public async Task<ServiceResponse<WatchHistoryDto>> Get(int userId)
        {
            return   _repository.GetList(userId);
        }

        // GET: api/api/v1/Users/{userId}/WatchHistorys/5
        [HttpGet]
        [Route("api/v1/Users/{userId}/WatchHistorys/{id}")]
        public async Task<ServiceResponse<WatchHistoryDto>> Get(int id, int userId)
        {
            return   _repository.GetById(id, userId);
        }

        // POST: api/api/v1/Users/{userId}/WatchHistorys
        [HttpPost]
        [Route("api/v1/Users/{userId}/WatchHistorys")]
        public async Task<ServiceResponse<WatchHistoryDto>> Post(int userId, WatchHistoryDto model)
        {
            return   _repository.Insert(userId, model);
        }

        [HttpPut]
        // PUT: api/api/v1/Users/{userId}/WatchHistorys/5
        [Route("api/v1/Users/{userId}/WatchHistorys/{id}")]
        public async Task<ServiceResponse<WatchHistoryDto>> Put(int id, int userId, WatchHistoryDto model)
        {
            return   _repository.Update(id, userId, model);
        }

        [HttpDelete]
        [Route("api/v1/Users/{userId}/WatchHistorys/{id}")]
        public async Task<ServiceResponse<WatchHistoryDto>> Delete(int id, int userId)
        {
            return _repository.Delete(id, userId);
        }

        [HttpPost]
        [Route("api/v1/WatchStatus")]
        public async Task<ServiceResponse<WatchHistoryDto>> WatchStatus(WatchHistoryDto model)
        {
            return _repository.WatchStatus(model);
        }

        [HttpGet]
        [Route("api/v1/GetByCourseId/{courseId}")]
        public async Task<ServiceResponse<WatchHistoryDto>> GetByCourseId(int courseId)
        {
            return _repository.GetByCourseId(courseId);
        }

        [HttpPost]
        [Route("api/v1/GetByDateTime")]
        public async Task<ServiceResponse<WatchHistoryDto>> GetByDateTime(WatchHistoryReqDto model)
        {
            return _repository.GetByDateTime(model);
        }

        [HttpPost]
        [Route("api/v1/StatisticTask")]
        public async Task<ServiceResponse<DayAnalyticsDto>> StatisticTask(WatchHistoryReqDto model)
        {
            return _repository.StatisticTask(model);
        }
    }
}
