using System.Linq;
using TimeClockData;

namespace TimeClock.Repositories
{
    public interface IEmployeeInfoRepository
    {
        IQueryable<EmployeeInfo> AllEmployees { get; }
        EmployeeInfo Save(EmployeeInfo employee);
        void Delete(EmployeeInfo employee);
        IQueryable<EmployeeInfo> GetClockedInEmployees();
        IQueryable<EmployeeInfo> GetClockedOutEmployees();
        EmployeeInfo SearchEmployees(int id);
        IQueryable<EmployeeInfo> SearchEmployees(string firstName, string lastName);

    }
}
