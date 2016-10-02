using System;
using System.Collections.Generic;
using TimeClock.Data;
using TimeClock.Reporting.Converters;
using TimeClock.Reporting.Helpers;

namespace TimeClock.Reporting
{
    public interface IReport
    {
        string ReportName { get; }
        Dictionary<string, string> HeaderFields { get; }
        ReportingFields Fields { get; }
        string GenerateReport(IEnumerable<EmployeeInfo> employees, DateTime beginRange, DateTime endRange);
        string GenerateReport(IEnumerable<int> employeeIds, DateTime beginRange, DateTime endRange);
        string ConvertReport(IConverter converter);
    }
}
