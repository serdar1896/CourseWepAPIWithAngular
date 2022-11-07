using System;

namespace GulaylarCase.Data.ViewModel
{
    public class WatchHistoryReqDto
    {
        public int CourseId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
