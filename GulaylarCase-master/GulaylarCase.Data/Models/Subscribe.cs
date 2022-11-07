using System;

namespace GulaylarCase.Data.Models
{
    public class Subscribe
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? CourseId { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? LastModified { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
