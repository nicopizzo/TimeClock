using System;
using System.Linq;
using System.Data.Entity;

namespace TimeClock.Data.Repositories
{
    public class EmployeeInfoRepository : RepositoryBase, IEmployeeInfoRepository
    {

        public EmployeeInfoRepository(TimeClockContext context, Guid companyId)
            : base(context, companyId)
        {
        }   
        
        public EmployeeInfoRepository(Guid companyId)
            : base(new TimeClockContext(), companyId)
        {
        }  

        public IQueryable<EmployeeInfo> AllEmployees
        {
            get
            {
                try
                {
                    return _context.EmployeeInfoes.Where(e => e.CompanyId == _companyId);
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
                return AllEmployees.Where(e => e.ClockHistories.Where(c => c.ClockOutTime == null).Any());
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
                return AllEmployees.Where(e => !e.ClockHistories.Where(c => c.ClockOutTime == null).Any());
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
                return AllEmployees.Where(e => e.EmployeeId == id).FirstOrDefault();
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
                return AllEmployees.Where(e =>
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
