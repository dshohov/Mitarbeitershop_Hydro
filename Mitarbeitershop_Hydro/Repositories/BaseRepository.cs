using Microsoft.EntityFrameworkCore;
using Mitarbeitershop_Hydro.Data;
using Mitarbeitershop_Hydro.IRepositories;

namespace Mitarbeitershop_Hydro.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdIternalAsync(string id)
        {
            if(id == null) throw new ArgumentNullException(nameof(id) + " + " + typeof(T));
            return await _dbSet.FindAsync(id);
        }

        public async Task AddIternalAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity) + " + " + typeof(T));
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIternalAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity) + " + " + typeof(T));
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIternalAsync(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id) + " + " + typeof(T));
            var entity = await GetByIdIternalAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<T> QueryIternal()
        {
            return _dbSet.AsQueryable();
        }
    }
}
