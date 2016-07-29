using System.Data.Entity;

namespace TimeClockData
{  
    public partial class TimeClockContext : DbContext
    {
        public TimeClockContext()
            : base("name=TimeClockContext")
        {
        }

        public virtual DbSet<ClockHistory> ClockHistories { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.Pay)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInfo>()
                .HasMany(e => e.ClockHistories)
                .WithRequired(e => e.EmployeeInfo)
                .WillCascadeOnDelete(false);
        }
    }
}
