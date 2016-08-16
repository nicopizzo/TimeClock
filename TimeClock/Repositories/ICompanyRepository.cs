using System;
using System.Linq;
using TimeClockData;

namespace TimeClock.Repositories
{
    public interface ICompanyRepository
    {
        IQueryable<Company> AllCompanies { get; }
        Company Save(Company company);
        void Delete(Company company);
        Company GetCompany(Guid id);
        IQueryable<Company> SearchCompany(string companyName);
        
    }
}
