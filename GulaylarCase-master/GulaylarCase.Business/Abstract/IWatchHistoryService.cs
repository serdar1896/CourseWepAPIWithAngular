using System;
using GulaylarCase.Data.ViewModel;

namespace GulaylarCase.Business.Abstract
{
    public interface IWatchHistoryService
    {
        ServiceResponse<WatchHistoryDto> GetList(int userId);
        ServiceResponse<WatchHistoryDto> Insert(int userId, WatchHistoryDto model);
        ServiceResponse<WatchHistoryDto> GetById(int id, int userId);
        ServiceResponse<WatchHistoryDto> Update(int id, int userId, WatchHistoryDto model);
        ServiceResponse<WatchHistoryDto> Delete(int id, int userId);
        ServiceResponse<WatchHistoryDto> WatchStatus(WatchHistoryDto model);
        ServiceResponse<WatchHistoryDto> GetByCourseId(int courseId);
        ServiceResponse<WatchHistoryDto> GetByDateTime(WatchHistoryReqDto model);
        ServiceResponse<DayAnalyticsDto> StatisticTask(WatchHistoryReqDto model);
    }
}
