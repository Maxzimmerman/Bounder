using Bounder.Data;
using Bounder.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bounder.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet { get; set; }

        public Repository(ApplicationDbContext applicationdbcontext)
        {
            _context = applicationdbcontext;
            this.dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetOne(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Create(T entry)
        {
            _context.Add(entry);
            _context.SaveChanges();
        }
    }
}
