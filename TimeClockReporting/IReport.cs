using System;
using TimeClockData;

namespace TimeClockReporting
{
    public interface IReport
    {
        string GenerateReport(EmployeeInfo employee, DateTime beginRange, DateTime endRange);
        string GenerateReport(int employeeId, DateTime beginRange, DateTime endRange);
    }
}
