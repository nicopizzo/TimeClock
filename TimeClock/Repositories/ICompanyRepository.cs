using System;
using System.Linq;
using TimeClock.Data;

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
