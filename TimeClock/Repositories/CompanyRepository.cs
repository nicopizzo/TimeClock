using System;
using System.Data.Entity;
using System.Linq;
using TimeClockData;

namespace TimeClock.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        protected readonly TimeClockContext _context;

        public CompanyRepository()
        {
            _context = new TimeClockContext();
        }

        public CompanyRepository(TimeClockContext context)
        {
            _context = context;
        }

        public IQueryable<Company> AllCompanies
        {
            get
            {
                try
                {
                    return _context.Companies;
                }
                catch
                {
                    throw;
                }
            }
        }

        public void Delete(Company company)
        {
            try
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }         
        }

        public Company GetCompany(Guid id)
        {
            try
            {
                return _context.Companies.Where(c =>
                    c.CompanyId == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }           
        }

        public Company Save(Company company)
        {
            try
            {
                if (company.CompanyId == Guid.Empty)
                {
                    company.CompanyId = Guid.NewGuid();
                    _context.Companies.Add(company);
                }
                else
                {
                    _context.Entry(company).State = EntityState.Modified;
                }
                _context.SaveChanges();
                return company;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<Company> SearchCompany(string companyName)
        {
            try
            {
                return _context.Companies.Where(c =>
                    c.CompanyName.Trim().ToUpper() == companyName.Trim().ToUpper());
            }
            catch
            {
                throw;
            }            
        }
    }
}
