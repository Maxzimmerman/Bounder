using Bounder.Data;
using Bounder.Models;
using Bounder.Repositories.IRepositories;

namespace Bounder.Repositories
{
    public class CompanyLocationRepository : Repository<CompanyLocation>, ICompanyLocationRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyLocationRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public void Update(CompanyLocation companyLocation)
        {
            _context.Update(companyLocation);
            _context.SaveChanges();
        }
    }
}
