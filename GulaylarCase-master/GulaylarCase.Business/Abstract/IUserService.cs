using GulaylarCase.Data.ViewModel;

namespace GulaylarCase.Business.Abstract
{
    public interface IUserService
    {
        ServiceResponse<UserDto> GetList();
        ServiceResponse<UserDto> Insert(UserDto model);
        ServiceResponse<UserDto> GetById(int id);
        ServiceResponse<UserDto> Update(UserDto model);
        ServiceResponse<UserDto> Delete(int id);
    }
}
