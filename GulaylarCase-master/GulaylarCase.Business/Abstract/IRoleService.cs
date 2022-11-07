using GulaylarCase.Data.ViewModel;

namespace GulaylarCase.Business.Abstract
{
    public interface IRoleService
    {
        ServiceResponse<RoleDto> GetList();
        ServiceResponse<RoleDto> Insert(RoleDto model);
        ServiceResponse<RoleDto> GetById(int id);
        ServiceResponse<RoleDto> Update(RoleDto model);
        ServiceResponse<RoleDto> Delete(int id);
    }
}
