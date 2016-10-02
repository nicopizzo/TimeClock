using System;
using System.Collections.Generic;
using TimeClock.Data.Repositories;
using TimeClock.Data;
using TimeClock.Reporting.Converters;
using TimeClock.Reporting.Helpers;

namespace TimeClock.Reporting
{
    public class BaseReport : IReport
    {     
        public string ReportName { get; set; }
        public Dictionary<string, string> HeaderFields { get; }
        public ReportingFields Fields { get; set; }
        protected IEmployeeInfoRepository EmployeeRepo { get; private set; }
        protected IClockHistoryRepository ClockHistoryRepo { get; private set; }
        protected Company Company { get; private set; }

        public BaseReport(Company company, IEmployeeInfoRepository employees, IClockHistoryRepository histories)
        {
            EmployeeRepo = employees;
            ClockHistoryRepo = histories;
            Company = company;
            HeaderFields = new Dictionary<string, string>();
            Fields = new ReportingFields();
            SetupHeaderFields();
        }

        public string ConvertReport(IConverter converter)
        {
            return converter.ConvertReport(this);
        }

        protected void AddField(string key, string value)
        {
            Fields.AddField(key, value);
        }

        private void AddHeaderField(string key, string value)
        {
            HeaderFields.Add(key, value);
        }

        private void SetupHeaderFields()
        {
            if(Company != null)
            {
                AddHeaderField(ReportingConstants.HEADER_COMPANY_NAME, Company.CompanyName);
                AddHeaderField(ReportingConstants.HEADER_COMPANY_ADDRESS, Company.Address);
                AddHeaderField(ReportingConstants.HEADER_COMPANY_CITY, Company.City);
                AddHeaderField(ReportingConstants.HEADER_COMPANY_STATE, Company.State);
                AddHeaderField(ReportingConstants.HEADER_COMPANY_ZIP, Company.Zip);
                AddHeaderField(ReportingConstants.HEADER_COMPANY_PHONE, Company.PhoneNumber);
                AddHeaderField(ReportingConstants.HEADER_COMPANY_FAX, Company.FaxNumber);
                AddHeaderField(ReportingConstants.HEADER_COMPANY_WEBSITE, Company.Website);
            }         
        }

        public virtual string GenerateReport(IEnumerable<EmployeeInfo> employee, DateTime beginRange, DateTime endRange)
        {
            throw new NotImplementedException();
        }

        public virtual string GenerateReport(IEnumerable<int> employeeId, DateTime beginRange, DateTime endRange)
        {
            throw new NotImplementedException();
        }
    }
}
