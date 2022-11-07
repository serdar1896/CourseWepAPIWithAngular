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
    public class UserService : IUserService
    {
        private IRepository<User> _repository;
        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public ServiceResponse<UserDto> Delete(int id)
        {
            var response = new ServiceResponse<UserDto>();
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

        public ServiceResponse<UserDto> GetById(int id)
        {
            var response = new ServiceResponse<UserDto>();
            try
            {
                var item = _repository.TableNoTracking.Include(x => x.Subscribe.Select(a => a.Course))
                    .FirstOrDefault(x => x.Id == id);

                if (item != null)
                {
                    response.Entity = new UserDto();
                    response.Entity.Id = item.Id;
                    response.Entity.FirstName = item.FirstName;
                    response.Entity.LastName = item.LastName;
                    response.Entity.Email = item.Email;
                    response.Entity.Password = item.Password;
                    response.Entity.Subscribe = item.Subscribe.Select(dtoData => new SubscribeDto
                        {
                            Id = dtoData.Id,
                            CourseId = dtoData.CourseId,
                            UserId = dtoData.UserId,
                            Course = new CourseDto
                            {
                                Id = dtoData.Course.Id,
                                Title = dtoData.Course.Title,
                                Slug = dtoData.Course.Slug,
                                Description = dtoData.Course.Description,
                                VideoUrl = dtoData.Course.VideoUrl
                            }
                        }
                    ).ToList();

                }

                response.IsSuccessful = true;
                if (response.Entity == null)
                {
                    response.IsSuccessful = false;
                    response.ExceptionMessage = ErrorCodes.KayitYok.Text;
                }


            }
            catch (Exception)
            {
                response.IsSuccessful = false;
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
            }

            return response;
        }

        public ServiceResponse<UserDto> GetList()
        {
            var response = new ServiceResponse<UserDto>();
            try
            {
                response.List = _repository.TableNoTracking.Select(m => new UserDto
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email,
                    Password = m.Password,
                    RoleId = m.RoleId

                }).ToList();
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }
            return response;
        }

        public ServiceResponse<UserDto> Insert(UserDto modelDto)
        {
            var response = new ServiceResponse<UserDto>();
            try
            {
                var model = new User();
                model.Id = modelDto.Id;
                model.FirstName = modelDto.FirstName;
                model.LastName = modelDto.LastName;
                model.Email = modelDto.Email;
                model.Password = modelDto.Password;
                model.RoleId = modelDto.RoleId;
                model.RoleId = modelDto.RoleId;
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

        public ServiceResponse<UserDto> Update(UserDto modelDto)
        {
            var response = new ServiceResponse<UserDto>();
            try
            {
                var model = new User();
                model.Id = modelDto.Id;
                model.FirstName = modelDto.FirstName;
                model.LastName = modelDto.LastName;
                model.Email = modelDto.Email;
                model.Password = modelDto.Password;
                model.RoleId = modelDto.RoleId;
                model.RoleId = modelDto.RoleId;
                model.DateAdded = DateTime.Now;


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
    }
}
