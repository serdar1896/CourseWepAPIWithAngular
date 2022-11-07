using GulaylarCase.Business.Abstract;
using GulaylarCase.Core.Abstract;
using GulaylarCase.Data.Enum;
using GulaylarCase.Data.Models;
using GulaylarCase.Data.ViewModel;
using System;
using System.Linq;

namespace GulaylarCase.Business.Concrete
{
    public class SubscribeService : ISubscribeService
    {
        private IRepository<Subscribe> _repository;
        public SubscribeService(IRepository<Subscribe> repository)
        {
            _repository = repository;
        }
        public ServiceResponse<SubscribeDto> Delete(int id, int userId)
        {
            var response = new ServiceResponse<SubscribeDto>();
            try
            {
                var query = _repository.Table.FirstOrDefault(a => a.Id == id && a.UserId == userId);
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

        public ServiceResponse<SubscribeDto> GetById(int id, int userId)
        {
            var response = new ServiceResponse<SubscribeDto>();
            try
            {
                var item = _repository.GetById(id);

                response.Entity.UserId = item.UserId;
                response.Entity.CourseId = item.CourseId;
                response.Entity.Id = item.Id;

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

        public ServiceResponse<SubscribeDto> GetList(int userId)
        {
            var response = new ServiceResponse<SubscribeDto>();
            try
            {
                response.List = _repository.TableNoTracking.Where(a => a.UserId == userId).Select(m => new SubscribeDto
                {
                    Id = m.Id,
                    UserId = m.UserId,
                    CourseId = m.CourseId

                }).ToList();
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }
            return response;
        }

        public ServiceResponse<SubscribeDto> Insert(int userId, SubscribeDto modelDto)
        {
            var response = new ServiceResponse<SubscribeDto>();
            try
            {
                if (modelDto != null && modelDto.UserId == userId)
                {
                    var item = _repository.TableNoTracking.FirstOrDefault(x =>
                        x.CourseId == modelDto.CourseId && x.UserId == modelDto.UserId);
                    if (item == null)
                    {
                        var model = new Subscribe();
                        model.UserId = modelDto.UserId;
                        model.CourseId = modelDto.CourseId;
                        model.Id = modelDto.Id;
                        model.DateAdded = DateTime.Now;

                        _repository.Insert(model);
                        response.IsSuccessful = true;
                    }
                }

            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }
            return response;
        }

        public ServiceResponse<SubscribeDto> Update(int id, int userId, SubscribeDto modelDto)
        {
            var response = new ServiceResponse<SubscribeDto>();
            try
            {
                if (modelDto.UserId == userId && modelDto.Id == id)
                {
                    var model = new Subscribe();
                    model.UserId = modelDto.UserId;
                    model.CourseId = modelDto.CourseId;
                    model.Id = modelDto.Id;
                    model.LastModified = DateTime.Now;


                    _repository.Update(model);
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
    }
}
