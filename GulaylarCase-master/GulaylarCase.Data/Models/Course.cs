using System;
using System.Collections.Generic;

namespace GulaylarCase.Data.Models
{
    public sealed class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Subscribe = new HashSet<Subscribe>();
            WatchHistory = new HashSet<WatchHistory>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? LastModified { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Subscribe> Subscribe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<WatchHistory> WatchHistory { get; set; }
    }
}
