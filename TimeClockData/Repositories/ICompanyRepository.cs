﻿using System;
using System.Linq;

namespace TimeClock.Data.Repositories
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
