using System;
using System.Collections.Generic;
using TimeClock.Repositories;
using TimeClockData;
using TimeClockReporting.Converters;
using TimeClockReporting.Helpers;

namespace TimeClockReporting
{
    public class BaseReport
    {     
        protected string ReportName { get; set; }
        protected Dictionary<string, string> HeaderFields { get; }
        protected Dictionary<string, string> Fields { get; set; }
        protected IEmployeeInfoRepository EmployeeRepo { get; private set; }
        protected IClockHistoryRepository ClockHistoryRepo { get; private set; }
        protected CompanyModel Company { get; private set; }

        public BaseReport(CompanyModel company, IEmployeeInfoRepository employees, IClockHistoryRepository histories)
        {
            EmployeeRepo = employees;
            ClockHistoryRepo = histories;
            Company = company;
            Fields = new Dictionary<string, string>();
            SetupHeaderFields();
        }

        public string ConvertReport(IConverter converter)
        {
            return converter.ConvertReport(this);
        }

        protected void AddField(string key, string value)
        {
            Fields.Add(key, value);
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
                AddHeaderField(ReportingConstants.HEADER_COMPANY_STATE, Company.State);
                AddHeaderField(ReportingConstants.HEADER_COMPANY_ZIP, Company.Zip);
                AddHeaderField(ReportingConstants.HEADER_COMPANY_PHONE, Company.PhoneNumber);
                AddHeaderField(ReportingConstants.HEADER_COMPANY_FAX, Company.FaxNumber);
                AddHeaderField(ReportingConstants.HEADER_COMPANY_WEBSITE, Company.Website);
            }         
        }

        

    }
}
