using System;
using System.Collections.Generic;

namespace GulaylarCase.Data.Models
{
    public sealed class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Subscribe = new HashSet<Subscribe>();
            WatchHistory = new HashSet<WatchHistory>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? RoleId { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? LastModified { get; set; }

        public bool? Deleted { get; set; }


        public Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Subscribe> Subscribe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<WatchHistory> WatchHistory { get; set; }
    }
}
