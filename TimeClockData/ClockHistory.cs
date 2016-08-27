namespace TimeClock.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClockHistory")]
    public partial class ClockHistory
    {
        [Key]
        public Guid RowId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime ClockInTime { get; set; }

        public DateTime? ClockOutTime { get; set; }

        public virtual EmployeeInfo EmployeeInfo { get; set; }
    }
}
