using System;
using System.Collections.Generic;
using TimeClock.Data;
using TimeClock.Reporting.Converters;

namespace TimeClock.Reporting
{
    public interface IReport
    {
        string ReportName { get; }
        Dictionary<string, string> HeaderFields { get; }
        Dictionary<string, string> Fields { get; }
        string GenerateReport(EmployeeInfo employee, DateTime beginRange, DateTime endRange);
        string GenerateReport(int employeeId, DateTime beginRange, DateTime endRange);
        string ConvertReport(IConverter converter);
    }
}
