using System;
using System.Linq;

namespace TimeClock.Data.Repositories
{
    public interface IClockHistoryRepository
    {
        IQueryable<ClockHistory> ClockHistories { get; }
        ClockHistory Save(ClockHistory history);
        void Delete(ClockHistory history);
        ClockHistory SearchHistory(Guid RowId);
        ClockHistory GetClockedInHistory(int employeeId);
    }
}
