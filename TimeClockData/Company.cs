using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TimeClock.Data
{
    [Table("Company")]
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            EmployeeInfoes = new HashSet<EmployeeInfo>();
        }

        public Guid CompanyId { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        public string FaxNumber { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        [StringLength(80)]
        public string CompanyPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeInfo> EmployeeInfoes { get; set; }
    }
}
