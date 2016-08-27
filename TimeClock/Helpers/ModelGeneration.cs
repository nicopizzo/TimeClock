using System;
using TimeClock.Data;
using TimeClock.Security;

namespace TimeClock.Helpers
{
    public static class ModelGeneration
    {
        public static EmployeeInfo GenerateEmployeeModel(Guid companyId, string firstName, string lastName, DateTime DOB, string phonenumber, decimal pay, bool isSalary, bool isActive, string password, string position, bool justHired)
        {
            EmployeeInfo employee = new EmployeeInfo()
            {
                CompanyId = companyId,
                FirstName = firstName,
                LastName = lastName,
                DOB = DOB,
                PhoneNumber = phonenumber,
                Pay = pay,
                IsSalary = isSalary,
                IsActive = isActive,
                Password = UserSecurity.CreateHash(password),
                Position = position
            };
            if (justHired)
            {
                employee.HiredDate = DateTime.Now;
            }
            return employee;
        }

        public static ClockHistory GenerateClockHistoryModel(int employeeId, DateTime clockInTime, DateTime? clockOutTime)
        {
            ClockHistory history = new ClockHistory()
            {
                EmployeeId = employeeId,
                ClockInTime = clockInTime,
                ClockOutTime = clockOutTime
            };
            return history;
        }

        public static Company GenerateCompanyModel(string companyName, string address, string city, string state, string zip, string phone, string fax, string website, string password)
        {
            Company company = new Company()
            {
                CompanyId = Guid.Empty,
                CompanyName = companyName,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                PhoneNumber = phone,
                FaxNumber = fax,
                Website = website,
                CompanyPassword = UserSecurity.CreateHash(password)
            };
            return company;
        }
    }
}
