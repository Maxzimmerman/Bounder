using Bounder.Data;
using Bounder.Models;
using Bounder.Repositories.IRepositories;

namespace Bounder.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public void Update(Location location)
        {
            _context.Update(location);
            _context.SaveChanges();
        }
    }
}
