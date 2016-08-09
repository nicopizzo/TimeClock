using System;
using System.Linq;
using TimeClockData;

namespace TimeClock.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyRepository()
        {

        }

        public IQueryable<CompanyModel> AllCompanies
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(CompanyModel company)
        {
            throw new NotImplementedException();
        }

        public CompanyModel GetCompany(Guid id)
        {
            throw new NotImplementedException();
        }

        public CompanyModel Save(CompanyModel company)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CompanyModel> SearchCompany(string companyName)
        {
            throw new NotImplementedException();
        }
    }
}
