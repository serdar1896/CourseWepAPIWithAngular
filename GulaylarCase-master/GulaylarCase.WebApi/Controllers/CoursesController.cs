using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using GulaylarCase.Business.Abstract;
using GulaylarCase.Data.ViewModel;

namespace GulaylarCase.WebApi.Controllers
{
    [RoutePrefix("api/v1/Courses")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CoursesController : ApiController
    {
        private ICourseService _repository;
        public CoursesController(ICourseService repository)
        {
            _repository = repository;
        }
        // GET: api/Courses
        [HttpGet]
        [Route("")]
        public ServiceResponse<CourseDto> Get()
        {
            return _repository.GetList();
        }

        // GET: api/Courses/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ServiceResponse<CourseDto>> Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST: api/Courses
        [HttpPost]
        [Route("")]
        public  ServiceResponse<CourseDto> Post(CourseDto model)
        {
            return  _repository.Insert(model);
        }

        // PUT: api/Courses/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ServiceResponse<CourseDto>> Put(int id, CourseDto model)
        {
            return   _repository.Update(model);
        }

        // DELETE: api/Courses/5
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ServiceResponse<CourseDto>> Delete(int id)
        {
            return _repository.Delete(id);
        }

    }
}
