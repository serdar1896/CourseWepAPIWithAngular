using GulaylarCase.Data.ViewModel;

namespace GulaylarCase.Business.Abstract
{
    public interface ISubscribeService
    {
        ServiceResponse<SubscribeDto> GetList(int userId);
        ServiceResponse<SubscribeDto> Insert(int userId, SubscribeDto model);
        ServiceResponse<SubscribeDto> GetById(int id, int userId);
        ServiceResponse<SubscribeDto> Update(int id, int userId, SubscribeDto model);
        ServiceResponse<SubscribeDto> Delete(int id, int userId);
    }
}
