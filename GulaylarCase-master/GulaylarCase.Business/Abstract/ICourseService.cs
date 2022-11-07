using GulaylarCase.Data.ViewModel;

namespace GulaylarCase.Business.Abstract
{
    public interface ICourseService
    {
        ServiceResponse<CourseDto> GetList();
        ServiceResponse<CourseDto> Insert(CourseDto model);
        ServiceResponse<CourseDto> GetById(int id);
        ServiceResponse<CourseDto> Update(CourseDto model);
        ServiceResponse<CourseDto> Delete(int id);
        
    }
}
