using Bounder.Models;

namespace Bounder.Repositories.IRepositories
{
    public interface ICompanyLocationRepository : IRepository<CompanyLocation>
    {
        void Update(CompanyLocation companyLocation);
    }
}
