using System;
using System.Linq;
using System.Data.Entity;
using TimeClockData;

namespace TimeClock.Repositories
{
    public class ClockHistoryRepository : IClockHistoryRepository
    {
        protected readonly TimeClockContext _context;

        public ClockHistoryRepository(TimeClockContext context)
        {
            _context = context;
        }

        public ClockHistoryRepository()
        {
            _context = new TimeClockContext();
        }

        public IQueryable<ClockHistory> ClockHistories
        {
            get
            {
                try
                {
                    return _context.ClockHistories;
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
                return _context.ClockHistories.Where(e => e.EmployeeId == employeeId && e.ClockOutTime == null).FirstOrDefault();
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
                return _context.ClockHistories.Where(h => h.RowId == rowId).FirstOrDefault();
            }
            catch
            {
                throw;
            }           
        }
    }
}
