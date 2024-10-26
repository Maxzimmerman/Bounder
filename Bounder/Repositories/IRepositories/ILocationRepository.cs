using Bounder.Models;

namespace Bounder.Repositories.IRepositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        void Update(Location location);
    }
}