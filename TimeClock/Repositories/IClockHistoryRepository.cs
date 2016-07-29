using System;
using System.Linq;
using TimeClockData;

namespace TimeClock.Repositories
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
