using System.Linq.Expressions;

namespace Bounder.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne(int id);
        void Create(T entry);
    }
}
