using System.Linq.Expressions;

namespace LaEscalonia.Repository
{
    public interface IRepositoryAsync<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetByID(int? id);
        Task<T> Insert(T entity);
        Task<T> Delete(int id);
        Task Update(T entity);
        Task<T?> Find(Expression<Func<T, bool>> expr);
        Task<List<T>?> FindAll(Expression<Func<T, bool>> expr);
        Task<List<T>?> GetAllWithInlcudes(params Expression<Func<T, object>>[] includes);
        Task<T?> GetWithInlcudes(Expression<Func<T, bool>> expr, params Expression<Func<T, object>>[] includes);
    }
}
