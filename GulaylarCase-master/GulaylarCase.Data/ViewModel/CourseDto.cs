using System.Collections.Generic;

namespace GulaylarCase.Data.ViewModel
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public List<SubscribeDto> Subscribe { get; set; }
        public List<WatchHistoryDto> WatchHistory { get; set; }
    }
}
