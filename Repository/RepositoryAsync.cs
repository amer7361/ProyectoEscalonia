using LaEscalonia.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LaEscalonia.Repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class, new()
    {
        private readonly EscaloniaContext _context;
        public RepositoryAsync(EscaloniaContext context)
        {
            _context = context;
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public async Task<T> Delete(int id)
        {
            T? entity = await EntitySet.FindAsync(id);
            if (entity == null)
            {
                return new T();
            }
            EntitySet.Remove(entity);
            await Save();
            return entity;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        public async Task<T?> Find(Expression<Func<T, bool>> expr)
        {
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(expr);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T?> GetByID(int? id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task<T> Insert(T entity)
        {
            EntitySet.Add(entity);
            await Save();
            return entity;
        }

        public Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Save();
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>?> FindAll(Expression<Func<T, bool>> expr)
        {
            return await EntitySet.AsNoTracking().Where(expr).ToListAsync();
        }

        public async Task<List<T>?> GetAllWithInlcudes(params Expression<Func<T, object>>[] includes)
        {
            var query = EntitySet.AsNoTracking();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<T?> GetWithInlcudes(Expression<Func<T, bool>> expr, params Expression<Func<T, object>>[] includes)
        {
            var query = EntitySet.AsNoTracking().Where(expr);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
