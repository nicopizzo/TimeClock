using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeClock.Data;
using TimeClock.Security;
using TimeClock.Helpers;

namespace TimeClock.UnitTests
{
    [TestClass]
    public class ModelGenerationTests
    {
        [TestMethod]
        public void DoesEmployeeModelGenerationWork()
        {
            EmployeeInfo emp1 = CreateTestEmployee();
            EmployeeInfo emp2 = ModelGeneration.GenerateEmployeeModel(Guid.Empty, "Test", "Case", Convert.ToDateTime("3/12/1992"), "1234567890", 100, false, true, "password", "Worker", false);
            emp2.HiredDate = Convert.ToDateTime("3/12/2016");
            Assert.AreEqual(emp1.EmployeeId, emp2.EmployeeId);
            Assert.AreEqual(emp1.FirstName, emp2.FirstName);
            Assert.AreEqual(emp1.LastName, emp2.LastName);
            Assert.AreEqual(emp1.DOB, emp2.DOB);
            Assert.AreEqual(emp1.PhoneNumber, emp2.PhoneNumber);
            Assert.AreEqual(emp1.Pay, emp2.Pay);
            Assert.AreEqual(emp1.IsActive, emp2.IsActive);
            Assert.AreEqual(emp1.IsSalary, emp2.IsSalary);
            Assert.AreNotEqual(emp1.Password, emp2.Password);
            Assert.AreEqual(emp1.Position, emp2.Position);
            Assert.AreEqual(emp1.HiredDate, emp2.HiredDate);
        }

        [TestMethod]
        public void DoesClockHistoryModelGenerationWork()
        {
            ClockHistory h1 = CreateTestClockHistory();
            ClockHistory h2 = ModelGeneration.GenerateClockHistoryModel(1, Convert.ToDateTime("3/12/2016"), Convert.ToDateTime("3/13/2016"));
            Assert.AreEqual(h1.EmployeeId, h2.EmployeeId);
            Assert.AreEqual(h1.ClockInTime, h2.ClockInTime);
            Assert.AreEqual(h1.ClockOutTime, h2.ClockOutTime);
            Assert.AreEqual(h1.RowId, h2.RowId);
        }

        [TestMethod]
        public void DoesCompanyModelGenerationWork()
        {
            Company c1 = CreateTestCompany();
            Company c2 = ModelGeneration.GenerateCompanyModel("HMC", "123 Main St", "Hartford", "CT", "06106", "123456789", "987654321", "www.web.com", "password");
            Assert.AreEqual(c1.CompanyId, c2.CompanyId);
            Assert.AreEqual(c1.CompanyName, c2.CompanyName);
            Assert.AreEqual(c1.Address, c2.Address);
            Assert.AreEqual(c1.City, c2.City);
            Assert.AreEqual(c1.State, c2.State);
            Assert.AreEqual(c1.Zip, c2.Zip);
            Assert.AreEqual(c1.PhoneNumber, c2.PhoneNumber);
            Assert.AreEqual(c1.FaxNumber, c2.FaxNumber);
            Assert.AreEqual(c1.Website, c2.Website);
            Assert.AreNotEqual(c1.CompanyPassword, c2.CompanyPassword);
        }

        private Company CreateTestCompany()
        {
            return new Company
            {
                CompanyId = Guid.Empty,
                CompanyName = "HMC",
                Address = "123 Main St",
                City = "Hartford",
                Zip = "06106",
                State = "CT",
                PhoneNumber = "123456789",
                FaxNumber = "987654321",
                Website = "www.web.com",
                CompanyPassword = UserSecurity.CreateHash("password")
            };
        }

        private EmployeeInfo CreateTestEmployee()
        {
            return new EmployeeInfo
            {
                CompanyId = Guid.Empty,
                EmployeeId = 0,
                FirstName = "Test",
                LastName = "Case",
                DOB = Convert.ToDateTime("3/12/1992"),
                PhoneNumber = "1234567890",
                Pay = 100,
                IsSalary = false,
                IsActive = true,
                Password = UserSecurity.CreateHash("password"),
                HiredDate = Convert.ToDateTime("3/12/2016"),
                Position = "Worker"
            };
        }

        private ClockHistory CreateTestClockHistory()
        {
            return new ClockHistory
            {
                EmployeeId = 1,
                RowId = Guid.Empty,
                ClockInTime = Convert.ToDateTime("3/12/2016"),
                ClockOutTime = Convert.ToDateTime("3/13/2016")
            };
        }
    }
}
