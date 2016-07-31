using TimeClock.Repositories;

namespace TimeClockReporting
{
    public class PayReport : BaseReport
    {
        private const string REPORT_NAME = "Pay Report";

        public PayReport(IEmployeeInfoRepository employees, IClockHistoryRepository histories)
            : base(employees, histories)
        {            
            ReportName = ReportName;
        }
    }
}
