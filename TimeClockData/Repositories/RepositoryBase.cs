using System;

namespace TimeClock.Data.Repositories
{
    public class RepositoryBase
    {
        protected readonly TimeClockContext _context;
        protected readonly Guid _companyId;

        protected RepositoryBase(TimeClockContext context, Guid companyId)
        {
            _context = context;
            _companyId = companyId;
        }

        protected RepositoryBase(TimeClockContext context)
        {
            _context = context;
        }
    }
}
