using System.Data.Entity;

namespace TimeClock.Data
{
    public partial class TimeClockContext : DbContext
    {
        public TimeClockContext()
            : base("name=TimeClockContext")
        {
        }

        public virtual DbSet<ClockHistory> ClockHistories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.FaxNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.EmployeeInfoes)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

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
