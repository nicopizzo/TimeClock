using System.Linq;
using System.Data.Entity;
using TimeClockData;

namespace TimeClock.Repositories
{
    public class EmployeeInfoRepository : IEmployeeInfoRepository
    {
        protected readonly TimeClockContext _context;

        public EmployeeInfoRepository(TimeClockContext context)
        {
            _context = context;
        }   
        
        public EmployeeInfoRepository()
        {
            _context = new TimeClockContext();
        }  

        public IQueryable<EmployeeInfo> AllEmployees
        {
            get
            {
                try
                {
                    return _context.EmployeeInfoes;
                }
                catch
                {
                    throw;
                }             
            }
        }

        public void Delete(EmployeeInfo employee)
        {
            try
            {
                _context.EmployeeInfoes.Remove(employee);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }          
        }

        public IQueryable<EmployeeInfo> GetClockedInEmployees()
        {
            try
            {
                return _context.EmployeeInfoes.Where(e =>
                e.ClockHistories.Where(c => c.ClockOutTime == null).Any());
            }
            catch
            {
                throw;
            }            
        }

        public IQueryable<EmployeeInfo> GetClockedOutEmployees()
        {
            try
            {
                return _context.EmployeeInfoes.Where(e =>
                    !e.ClockHistories.Where(c => c.ClockOutTime == null).Any());
            }
            catch
            {
                throw;
            }          
        }

        public EmployeeInfo Save(EmployeeInfo employee)
        {
            try
            {
                if (employee.EmployeeId == 0)
                {
                    _context.EmployeeInfoes.Add(employee);
                }
                else
                {
                    _context.Entry(employee).State = EntityState.Modified;
                }
                _context.SaveChanges();
                return employee;
            }
            catch
            {
                throw;
            }          
        }

        public EmployeeInfo SearchEmployees(int id)
        {
            try
            {
                return _context.EmployeeInfoes.Where(e => e.EmployeeId == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }           
        }

        public IQueryable<EmployeeInfo> SearchEmployees(string firstName, string lastName)
        {
            try
            {
                return _context.EmployeeInfoes.Where(e =>
                    e.FirstName.Trim().ToUpper().Contains(firstName.Trim().ToUpper()) &&
                    e.LastName.Trim().ToUpper().Contains(lastName.Trim().ToUpper()));
            }
            catch
            {
                throw;
            }           
        }

    }
}
