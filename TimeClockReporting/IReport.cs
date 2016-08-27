using System;
using TimeClock.Data;

namespace TimeClock.Reporting
{
    public interface IReport
    {
        string GenerateReport(EmployeeInfo employee, DateTime beginRange, DateTime endRange);
        string GenerateReport(int employeeId, DateTime beginRange, DateTime endRange);
    }
}
