using System;
using System.Collections.Generic;
using System.Linq;
using TimeClock.Data.Repositories;
using TimeClock.DisplayModels;
using TimeClock.Security;
using TimeClock.Helpers;
using TimeClock.Data;


namespace TimeClock
{
    public class TimeClockProc
    {
        public Company Company { get; private set; }

        public TimeClockProc()
        {
            InitProcs();
        }

        private void InitProcs()
        {
            try
            {
                var id = Settings.Default.CompanyId;
                Company = GetCompany(id);
                SaveCompanyGuid(id);
            }
            catch
            {
                throw;
            }           
        }

        public void SaveCompanyGuid(Guid id)
        {
            Settings.Default.CompanyId = id;
            Settings.Default.Save();
        }

        public bool ProcessCompany(Company company)
        {
            try
            {
                var companies = new CompanyRepository();
                companies.Save(company);
            }
            catch
            {
                throw;
            }
            return true;
        }

        public Company GetCompany(Guid companyId)
        {
            try
            {
                var companies = new CompanyRepository();
                return companies.GetCompany(companyId);
            }
            catch
            {
                throw;
            }           
        }

        public bool ProcessEmployee(EmployeeInfo employee)
        {
            try
            {
                var employees = new EmployeeInfoRepository(Company.CompanyId);
                employees.Save(employee);
                
            }
            catch
            {
                throw;
            }          
            return true;
        }

        public bool RemoveEmployee(EmployeeInfo employee)
        {
            try
            {
                var employees = new EmployeeInfoRepository(Company.CompanyId);
                employees.Delete(employee);
            }
            catch
            {
                throw;
            }
            return true;
        }

        public List<EmployeeInfo> GetAllEmployees()
        {
            try
            {
                var employees = new EmployeeInfoRepository(Company.CompanyId);
                return employees.AllEmployees.ToList();
            }
            catch
            {
                throw;
            }            
        }

        public List<EmployeeInfo> GetClockedInEmployees()
        {
            try
            {
                var employees = new EmployeeInfoRepository(Company.CompanyId);
                return employees.GetClockedInEmployees().ToList();
            }
            catch
            {
                throw;
            }           
        }


        public List<ClockedInEmployeeGridModel> GetClockedInEmployeesView()
        {
            try
            {
                List<ClockedInEmployeeGridModel> models = new List<ClockedInEmployeeGridModel>();
                GetClockedInEmployees().ForEach(f => models.Add(new ClockedInEmployeeGridModel(f)));
                return models;            
            }            
            catch
            {
                throw;
            }
        }


        public List<EmployeeInfo> GetClockedOutEmployees()
        {
            try
            {
                var employees = new EmployeeInfoRepository(Company.CompanyId);
                return employees.GetClockedOutEmployees().ToList();              
            }
            catch
            {
                throw;
            }            
        }

        public bool VerifyEmployeePassword(int employeeId, string password)
        {
            try
            {
                var employees = new EmployeeInfoRepository(Company.CompanyId);
                var employee = employees.SearchEmployees(employeeId);
                return UserSecurity.VerifyPassword(password, employee.Password);               
            }
            catch
            {
                throw;
            }
        }


        #region Clock In Employees
        public bool ClockInEmployee(EmployeeInfo employee)
        {
            try
            {
                return ClockInEmployee(employee, DateTime.Now);
            }
            catch
            {
                throw;
            }            
        }

        public bool ClockInEmployee(EmployeeInfo employee, DateTime inTime)
        {
            // first verify employee is clocked out
            try
            {
                var histories = new ClockHistoryRepository(Company.CompanyId);
                if (IsClockedOut(employee.EmployeeId))
                {
                    // save history
                    var history = ModelGeneration.GenerateClockHistoryModel(employee.EmployeeId, inTime, null);
                    histories.Save(history);
                }
            }
            catch
            {
                throw;
            }      
            return true;
        }

        

        public bool ClockInEmployee(int id)
        {
            try
            {
                var employees = new EmployeeInfoRepository(Company.CompanyId);
                var employee = employees.SearchEmployees(id);
                if (employee != null)
                {
                    return ClockInEmployee(employee);
                }
            }
            catch
            {
                throw;
            }
            
            // should never reach here
            return false;
        }
        #endregion

        #region Clock Out Employees
        public bool ClockOutEmployee(EmployeeInfo employee)
        {
            try
            {
                return ClockOutEmployee(employee, DateTime.Now);
            }
            catch
            {
                throw;
            }          
        }

        public bool ClockOutEmployee(EmployeeInfo employee, DateTime outTime)
        {
            // first verify employee is clocked in
            try
            {
                var histories = new ClockHistoryRepository(Company.CompanyId);
                if (IsClockedIn(employee.EmployeeId))
                {
                    // save history
                    var history = histories.GetClockedInHistory(employee.EmployeeId);
                    history.ClockOutTime = outTime;
                    histories.Save(history);
                }
            }
            catch
            {
                throw;
            }
            return true;
        }

        public bool ClockOutEmployee(int id)
        {
            try
            {
                return ClockOutEmployee(id, DateTime.Now);
            }
            catch
            {
                throw;
            }           
        }

        public bool ClockOutEmployee(int id, DateTime outTime)
        {
            try
            {
                var employees = new EmployeeInfoRepository(Company.CompanyId);
                var employee = employees.SearchEmployees(id);
                return ClockOutEmployee(employee, outTime);             
            }
            catch
            {
                throw;
            }         
        }
        #endregion

        public EmployeeInfo SearchEmployee(int id)
        {
            try
            {
                var employees = new EmployeeInfoRepository(Company.CompanyId);
                return employees.SearchEmployees(id);                          
            }
            catch
            {
                throw;
            }        
        }

        public List<EmployeeInfo> SearchEmployee(string firstName, string lastName)
        {
            try
            {
                var employees = new EmployeeInfoRepository(Company.CompanyId);
                return employees.SearchEmployees(firstName, lastName).ToList();           
            }
            catch
            {
                throw;
            }
        }

        public bool IsClockedIn(int employeeId)
        {
            try
            {
                var result = false;
                var histories = new ClockHistoryRepository(Company.CompanyId);
                var history = histories.GetClockedInHistory(employeeId);
                if (history != null)
                {
                    result = true;
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        public bool IsClockedOut(int employeeId)
        {
            try
            {
                var result = false;
                var histories = new ClockHistoryRepository(Company.CompanyId);
                var history = histories.GetClockedInHistory(employeeId);
                if (history == null)
                {
                    result = true;
                }
                return result;

            }
            catch
            {
                throw;
            }
        }


    }
}
