using GulaylarCase.Business.Abstract;
using GulaylarCase.Core.Abstract;
using GulaylarCase.Data.Enum;
using GulaylarCase.Data.Models;
using GulaylarCase.Data.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;

namespace GulaylarCase.Business.Concrete
{
    public class CourseService : ICourseService
    {
        private IRepository<Course> _repository;
        public CourseService(IRepository<Course> repository)
        {
            _repository = repository;
        }
        public ServiceResponse<CourseDto> Delete(int id)
        {
            var response = new ServiceResponse<CourseDto>();
            try
            {
                var query = _repository.GetById(id);
                if (query != null)
                {
                    _repository.Delete(query);
                    response.IsSuccessful = true;
                }
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }
            return response;
        }

        public ServiceResponse<CourseDto> GetById(int id)
        {
            var response = new ServiceResponse<CourseDto>();
            try
            {

                var item = _repository.TableNoTracking.Include(x => x.Subscribe.Select(a => a.User)).FirstOrDefault(x => x.Id == id);

                if (item != null)
                {
                    response.Entity =new CourseDto();
                    response.Entity.Slug = item.Slug;
                    response.Entity.Description = item.Description;
                    response.Entity.Title = item.Title;
                    response.Entity.VideoUrl = item.VideoUrl;
                    response.Entity.Id = item.Id;
                    response.Entity.WatchHistory = item.WatchHistory.Select(m => new WatchHistoryDto
                    {
                        Id = m.Id,
                        UserId = m.UserId,
                        CourseId = m.CourseId
                    }).ToList();
                    response.Entity.Subscribe = item.Subscribe.Select(m => new SubscribeDto
                    {
                        Id = m.Id,
                        UserId = m.UserId,
                        CourseId = m.CourseId,
                        User = new UserDto { Id = m.User.Id, FirstName = m.User.FirstName, LastName = m.User.LastName, Email = m.User.Email }
                    }).ToList();
                }

                response.IsSuccessful = true;
                if (response.Entity == null)
                {
                    response.IsSuccessful = false;
                    response.ExceptionMessage = ErrorCodes.KayitYok.Text;
                }
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
            }
            return response;
        }


        public ServiceResponse<CourseDto> Insert(CourseDto modelDto)
        {
            var response = new ServiceResponse<CourseDto>();
            try
            {
                var model = new Course();

                model.Title = modelDto.Title;
                model.Slug = modelDto.Slug;
                model.Description = modelDto.Description;
                model.VideoUrl = modelDto.VideoUrl;
                model.DateAdded = DateTime.Now;

                _repository.Insert(model);
                response.IsSuccessful = true;
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }
            return response;
        }

        public ServiceResponse<CourseDto> Update(CourseDto modelDto)
        {
            var response = new ServiceResponse<CourseDto>();
            try
            {
                var model = new Course();

                model.Id = modelDto.Id;
                model.Title = modelDto.Title;
                model.Slug = modelDto.Slug;
                model.Description = modelDto.Description;
                model.VideoUrl = modelDto.VideoUrl;
                model.LastModified = DateTime.Now;

                _repository.Update(model);
                response.IsSuccessful = true;
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }
            return response;
        }

        public ServiceResponse<CourseDto> GetList()
        {
            var response = new ServiceResponse<CourseDto>();
            try
            {
                response.List = _repository.TableNoTracking.Select(m => new CourseDto
                {
                    Slug = m.Slug,
                    Title = m.Title,
                    Description = m.Description,
                    VideoUrl = m.VideoUrl,
                    Id = m.Id
                }).ToList();
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }

            return response;
        }

    }
}
