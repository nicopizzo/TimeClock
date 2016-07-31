using System;
using System.Collections.Generic;
using TimeClock.Repositories;
using TimeClockReporting.Converters;

namespace TimeClockReporting
{
    public class BaseReport
    {
        protected string ReportName { get; set; }
        protected Dictionary<string, string> Fields { get; set; }
        protected IEmployeeInfoRepository EmployeeRepo { get; private set; }
        protected IClockHistoryRepository ClockHistoryRepo { get; private set; }

        public BaseReport(IEmployeeInfoRepository employees, IClockHistoryRepository histories)
        {
            EmployeeRepo = employees;
            ClockHistoryRepo = histories;
            Fields = new Dictionary<string, string>();
        }

        public string ConvertReport(IConverter converter)
        {
            return converter.ConvertReport(this);
        }

    }
}
