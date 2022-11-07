using GulaylarCase.Data.Enum;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using GulaylarCase.Business.Abstract;
using GulaylarCase.Core.Abstract;
using GulaylarCase.Data.Models;
using GulaylarCase.Data.ViewModel;

namespace GulaylarCase.Business.Concrete
{
    public class WatchHistoryService : IWatchHistoryService
    {
        private IRepository<WatchHistory> _repository;

        public WatchHistoryService(IRepository<WatchHistory> repository)
        {
            _repository = repository;
        }

        public ServiceResponse<WatchHistoryDto> Delete(int id, int userId)
        {
            var response = new ServiceResponse<WatchHistoryDto>();
            try
            {
                var item = _repository.TableNoTracking.FirstOrDefault(x => x.Id == id && x.UserId == userId);
                response.IsSuccessful = true;
                if (item != null && (response.Entity == null && item.UserId == userId))
                {
                    _repository.Delete(item);
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

        public ServiceResponse<WatchHistoryDto> GetByCourseId(int courseId)
        {
            var response = new ServiceResponse<WatchHistoryDto>();
            try
            {
                response.List = _repository.TableNoTracking.Where(x => x.CourseId == courseId && EntityFunctions.TruncateTime(x.DateAdded) == EntityFunctions.TruncateTime(DateTime.Now)).Select(m =>
                    new WatchHistoryDto
                    {
                        CourseId = m.CourseId,
                        UserId = m.UserId
                    }).ToList();
                 

                response.IsSuccessful = true;
                if (response.List == null)
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

        [Obsolete]
        public ServiceResponse<WatchHistoryDto> GetByDateTime(WatchHistoryReqDto model)
        {
            var response = new ServiceResponse<WatchHistoryDto>();
            try
            {
                response.List = _repository.TableNoTracking.Include(x => x.User).Where(x => x.CourseId == model.CourseId && EntityFunctions.TruncateTime(x.DateAdded) == EntityFunctions.TruncateTime(model.StartDate)).Select(m =>
                    new WatchHistoryDto
                    {
                        CourseId = m.CourseId,
                        UserId = m.UserId,
                        User = new UserDto
                        {
                            Email = m.User.Email,
                            FirstName = m.User.FirstName,
                            Id = m.User.Id,
                            LastName = m.User.LastName,
                            Password = m.User.Password,
                            RoleId = m.User.RoleId
                        }
                    }).ToList();


                response.IsSuccessful = true;
                if (response.List == null)
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

        public ServiceResponse<WatchHistoryDto> GetById(int id, int userId)
        {
            var response = new ServiceResponse<WatchHistoryDto>();
            try
            {
                var item = _repository.TableNoTracking.FirstOrDefault(x => x.Id == id && x.UserId == userId);

                if (item != null)
                {
                    response.Entity.CourseId = item.CourseId;
                    response.Entity.Id = item.Id;
                    response.Entity.UserId = item.UserId;
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

        public ServiceResponse<WatchHistoryDto> GetList(int userId)
        {
            var response = new ServiceResponse<WatchHistoryDto>();
            try
            {
                response.List = _repository.TableNoTracking.Where(x => x.UserId == userId).Select(m =>
                    new WatchHistoryDto
                    {
                        Id = m.Id,
                        UserId = m.UserId,
                        CourseId = m.CourseId,

                    }).ToList();
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }

            return response;
        }

        public ServiceResponse<WatchHistoryDto> Insert(int userId, WatchHistoryDto model)
        {
            var response = new ServiceResponse<WatchHistoryDto>();
            try
            {
                var item = new WatchHistory();
                item.UserId = userId;
                item.CourseId = model.CourseId;
                item.DateAdded = DateTime.Now;


                _repository.Insert(item);
                response.IsSuccessful = true;
            }
            catch (Exception)
            {
                response.ExceptionMessage = ErrorCodes.BilinmeyenHata.Text;
                response.IsSuccessful = false;
            }

            return response;
        }

        public ServiceResponse<DayAnalyticsDto> StatisticTask(WatchHistoryReqDto model)
        {
            var response = new ServiceResponse<DayAnalyticsDto>();
            try
            {
                var dataAnalytics = _repository.TableNoTracking.Where(x =>
                    x.CourseId == model.CourseId &&
                    EntityFunctions.TruncateTime(x.DateAdded) >= EntityFunctions.TruncateTime(model.StartDate) &&
                    EntityFunctions.TruncateTime(x.DateAdded) <= EntityFunctions.TruncateTime(model.EndDate)
                );

                response.List = dataAnalytics.ToList().Select(k => new { k.DateAdded.Date, k.UserId }).GroupBy(x => new { x.Date }, (key, group) => new DayAnalyticsDto
                {
                    NowDate = key.Date,
                    CountData = group.Count(k => k.UserId.HasValue)
                }).OrderBy(x=> x.NowDate).ToList();



                response.IsSuccessful = true;
                if (response.List == null)
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

        public ServiceResponse<WatchHistoryDto> Update(int id, int userId, WatchHistoryDto model)
        {
            var response = new ServiceResponse<WatchHistoryDto>();
            try
            {
                model.UserId = userId;
                if (model.Id == id)
                {
                    var item = new WatchHistory();
                    item.UserId = userId;
                    item.Id = model.Id;
                    item.CourseId = model.CourseId;

                    _repository.Update(item);
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

        public ServiceResponse<WatchHistoryDto> WatchStatus(WatchHistoryDto watchHistoryDto)
        {
            if (watchHistoryDto.UserId != null && watchHistoryDto.CourseId != null)
            {

                var item = _repository.Table.FirstOrDefault(x => x.CourseId == watchHistoryDto.CourseId && x.UserId == watchHistoryDto.UserId && EntityFunctions.TruncateTime(x.DateAdded) == EntityFunctions.TruncateTime(DateTime.Now));

                if (item != null)
                {
                    _repository.Delete(item);
                }
                else
                {
                    _repository.Insert(new WatchHistory { CourseId = watchHistoryDto.CourseId, UserId = watchHistoryDto.UserId, DateAdded = DateTime.Now });
                }
            }

            return null;
        }
    }
}
