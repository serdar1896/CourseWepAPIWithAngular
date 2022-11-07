using System.Threading.Tasks;
using System.Web.Http;
using GulaylarCase.Business.Abstract;
using GulaylarCase.Data.ViewModel;

namespace GulaylarCase.WebApi.Controllers
{
    [Route("api/v1/Roles")]
    public class RolesController : ApiController
    {
        private IRoleService _repository;
        public RolesController(IRoleService repository)
        {
            _repository = repository;
        }
        // GET: api/Roles
        public async Task<ServiceResponse<RoleDto>> Get()
        {
            return   _repository.GetList();
        }

        // GET: api/Roles/5
        public async Task<ServiceResponse<RoleDto>> Get(int id)
        {
            return   _repository.GetById(id);
        }

        // POST: api/Roles
        public async Task<ServiceResponse<RoleDto>> Post(RoleDto model)
        {
            return   _repository.Insert(model);
        }

        // PUT: api/Roles/5
        public async Task<ServiceResponse<RoleDto>> Put(int id, RoleDto model)
        {
            return   _repository.Update(model);
        }

        // DELETE: api/Roles/5
        public async Task<ServiceResponse<RoleDto>> Delete(int id)
        {
            return   _repository.Delete(id);
        }
    }
}
