using System;
using System.Linq;
using TimeClock.Data;

namespace TimeClock.DisplayModels
{
    public class ClockedInEmployeeGridModel
    {
        private int _employeeId;
        private string _firstName;
        private string _lastName;
        private DateTime _clockInTime;

        private int EmployeeId
        {
            get
            {
                return _employeeId;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
        }
        public string ClockedInTime
        {
            get
            {
                return _clockInTime.ToString("MM/dd/yyyy HH:mm:ss tt");
            }
        }

        public ClockedInEmployeeGridModel(EmployeeInfo employee)
        {
            _employeeId = employee.EmployeeId;
            _firstName = employee.FirstName;
            _lastName = employee.LastName;
            _clockInTime = employee.ClockHistories.Where(h => h.ClockOutTime == null).FirstOrDefault().ClockInTime;
        }

        public int GetEmployeeId()
        {
            return EmployeeId;
        }
    }
}
