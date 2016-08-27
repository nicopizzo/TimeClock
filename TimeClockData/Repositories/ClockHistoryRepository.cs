using System;
using System.Linq;
using System.Data.Entity;

namespace TimeClock.Data.Repositories
{
    public class ClockHistoryRepository : RepositoryBase, IClockHistoryRepository
    {

        public ClockHistoryRepository(TimeClockContext context, Guid companyId)
            : base(context, companyId)
        {
        }

        public ClockHistoryRepository(Guid companyId)
            : base(new TimeClockContext(), companyId)
        {
        }

        public IQueryable<ClockHistory> ClockHistories
        {
            get
            {
                try
                {
                    return (from c in _context.ClockHistories
                            join e in _context.EmployeeInfoes
                            on c.EmployeeId equals e.EmployeeId
                            where e.CompanyId == _companyId
                            select c);
                }
                catch
                {
                    throw;
                }             
            }
        }

        public void Delete(ClockHistory history)
        {
            try
            {
                _context.ClockHistories.Remove(history);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }         
        }

        public ClockHistory GetClockedInHistory(int employeeId)
        {
            try
            {
                return ClockHistories.Where(e => e.EmployeeId == employeeId && e.ClockOutTime == null).FirstOrDefault();
            }
            catch
            {
                throw;
            }           
        }

        public ClockHistory Save(ClockHistory history)
        {
            try
            {
                if (history.RowId == Guid.Empty)
                {
                    history.RowId = Guid.NewGuid();
                    _context.ClockHistories.Add(history);
                }
                else
                {
                    _context.Entry<ClockHistory>(history).State = EntityState.Modified;
                }
                _context.SaveChanges();
                return history;
            }
            catch
            {
                throw;
            }
            
        }

        public ClockHistory SearchHistory(Guid rowId)
        {
            try
            {
                return ClockHistories.Where(h => h.RowId == rowId).FirstOrDefault();
            }
            catch
            {
                throw;
            }           
        }
    }
}
