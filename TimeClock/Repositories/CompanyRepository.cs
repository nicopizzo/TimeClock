using System;
using System.Data.Entity;
using System.Linq;
using TimeClock.Data;

namespace TimeClock.Repositories
{
    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {

        public CompanyRepository()
            : base(new TimeClockContext())
        {
        }

        public CompanyRepository(TimeClockContext context)
            : base(context)
        {
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
