﻿using System;
using TimeClockData;
using TimeClock.Security;

namespace TimeClock.Helpers
{
    public static class ModelGeneration
    {
        public static EmployeeInfo GenerateEmployeeModel(string firstName, string lastName, DateTime DOB, string phonenumber, decimal pay, bool isSalary, bool isActive, string password, string position, bool justHired)
        {
            EmployeeInfo employee = new EmployeeInfo()
            {
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
    }
}