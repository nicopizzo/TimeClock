﻿using System;
using System.Collections.Generic;
using System.Linq;
using TimeClock.Data.Repositories;
using TimeClock.Data;
using TimeClock.Reporting.Helpers;

namespace TimeClock.Reporting
{
    public class PayReport : BaseReport, IReport
    {
        private const string REPORT_NAME = "Pay Report";

        public PayReport(Company company, IEmployeeInfoRepository employees, IClockHistoryRepository histories)
            : base(company, employees, histories)
        {            
            ReportName = REPORT_NAME;
        }

        public PayReport(Company company)
            : base(company, new EmployeeInfoRepository(company.CompanyId), new ClockHistoryRepository(company.CompanyId))
        {
            ReportName = REPORT_NAME;
        }

        public override string GenerateReport(IEnumerable<int> employeeIds, DateTime beginRange, DateTime endRange)
        {
            var employees = new List<EmployeeInfo>();
            foreach(var id in employeeIds)
            {
                var employee = EmployeeRepo.SearchEmployees(id);
                employees.Add(employee);
            }
            
            return GenerateReport(employees, beginRange, endRange);
        }

        public override string GenerateReport(IEnumerable<EmployeeInfo> employees, DateTime beginRange, DateTime endRange)
        {
            foreach(var employee in employees)
            {
                Fields.AddEmployee(employee);
                var histories = employee.ClockHistories.Where(h => h.ClockInTime >= beginRange && h.ClockInTime <= endRange).ToList();
                var totalHours = CalculateHours(histories);
                var totalPay = CalculatePay(totalHours, employee.Pay.Value);

                AddField(ReportingConstants.FIELD_REPORT_RANGE, $"{beginRange.ToString("MM/dd/yyyy")} - {endRange.ToString("MM/dd/yyyy")}");
                AddField(ReportingConstants.FIELD_EMPLOYEE_NAME, $"{employee.FirstName} {employee.LastName}");
                AddField(ReportingConstants.FIELD_TOTAL_HOURS, totalHours.ToString());
                AddField(ReportingConstants.FIELD_PAYRATE, employee.Pay.Value.ToString());
                AddField(ReportingConstants.FIELD_TOTAL_PAY, totalPay.ToString());
            }

            return string.Empty;
            
        }

        private double CalculateHours(List<ClockHistory> histories)
        {
            double totalHours = 0;
            foreach(var history in histories)
            {
                totalHours += (history.ClockOutTime.Value - history.ClockInTime).TotalHours;
            }
            return totalHours;
        }

        private decimal CalculatePay(double hours, decimal payRate)
        {
            return (decimal)hours * payRate;
        }
    }
}
