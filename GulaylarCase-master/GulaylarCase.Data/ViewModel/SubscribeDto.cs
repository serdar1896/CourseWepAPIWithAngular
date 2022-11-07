namespace GulaylarCase.Data.ViewModel
{
    public class SubscribeDto
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? UserId { get; set; }
        public UserDto User { get; set; }
        public CourseDto Course { get; set; }
    }
}
