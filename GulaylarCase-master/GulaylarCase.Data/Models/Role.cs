using System;
using System.Collections.Generic;

namespace GulaylarCase.Data.Models
{
    public sealed class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? LastModified { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<User> User { get; set; }
    }
}
