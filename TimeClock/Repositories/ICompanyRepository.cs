using System;
using System.Linq;
using TimeClockData;

namespace TimeClock.Repositories
{
    public interface ICompanyRepository
    {
        IQueryable<CompanyModel> AllCompanies { get; }
        CompanyModel Save(CompanyModel company);
        void Delete(CompanyModel company);
        CompanyModel GetCompany(Guid id);
        IQueryable<CompanyModel> SearchCompany(string companyName);
        
    }
}
