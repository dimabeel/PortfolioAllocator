using System.Linq.Expressions;

namespace Allocator.API.DAL.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(int id);

    Task<IEnumerable<T>> GetAll();

    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);

    Task<T> Add(T entity);

    Task AddRange(IEnumerable<T> entities);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entities);

    T Update(T entity);
}