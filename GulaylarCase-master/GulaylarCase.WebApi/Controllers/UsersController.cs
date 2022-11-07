using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using GulaylarCase.Business.Abstract;
using GulaylarCase.Data.ViewModel;

namespace GulaylarCase.WebApi.Controllers
{
    [RoutePrefix("api/v1/Users")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private IUserService _repository;
        public UsersController(IUserService repository)
        {
            _repository = repository;
        }
        // GET: api/Users
        [HttpGet]
        [Route("")]
        public async Task<ServiceResponse<UserDto>> GetUser()
        {
            return   _repository.GetList();
        }

        // GET: api/Users/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ServiceResponse<UserDto>> GetUser(int id)
        {
            return   _repository.GetById(id);
        }

        // POST: api/Users
        [HttpPost]
        [Route("")]
        public async Task<ServiceResponse<UserDto>> PostUser(UserDto user)
        {
            return   _repository.Insert(user);
        }

        // PUT: api/Users/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ServiceResponse<UserDto>> PutUser(int id, UserDto user)
        {
            return   _repository.Update(user);
        }

        // DELETE: api/Users/5
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ServiceResponse<UserDto>> DeleteUser(int id)
        {
            return   _repository.Delete(id);
        }
    }
}