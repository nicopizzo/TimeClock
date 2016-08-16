namespace TimeClockData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeInfo")]
    public partial class EmployeeInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeInfo()
        {
            ClockHistories = new HashSet<ClockHistory>();
        }

        [Key]
        public int EmployeeId { get; set; }

        public Guid CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal? Pay { get; set; }

        public bool? IsSalary { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(80)]
        public string Password { get; set; }

        public DateTime? HiredDate { get; set; }

        [StringLength(30)]
        public string Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClockHistory> ClockHistories { get; set; }

        public virtual Company Company { get; set; }
    }
}
