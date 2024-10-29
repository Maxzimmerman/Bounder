using Bounder.Models;

namespace Bounder.Repositories.IRepositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
    }
}
