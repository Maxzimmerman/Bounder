using Bounder.Data;
using Bounder.Models;
using Bounder.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Bounder.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository 
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        } 

        public void Update(Company company)
        {
            _context.Update(company);
            _context.SaveChanges();
        }

        public async override Task<IEnumerable<Company>> GetAll()
        {
            var companies = await _context.Clients.Include(c => c.Area).ToListAsync();
            if (companies != null)
                return companies;
            else
                return null;
        }
    }
}
