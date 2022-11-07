namespace GulaylarCase.Data.ViewModel
{
    public class WatchHistoryDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public UserDto User { get; set; }
    }
}
