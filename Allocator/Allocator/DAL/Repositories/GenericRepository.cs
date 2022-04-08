using System.Linq.Expressions;
using Allocator.API.DAL.Context;
using Allocator.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Allocator.API.DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : SystemEntity
{
    private readonly AllocatorContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AllocatorContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id) ?? Activator.CreateInstance<T>();
    }

    public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        => await _dbSet.Where(expression).ToListAsync();

    public async Task<T> Add(T entity)
    {
        var result = await _dbSet.AddAsync(entity);
        return result.Entity;
    }

    public void Remove(T entity) => entity.IsDeleted = true;

    public void RemoveRange(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            entity.IsDeleted = true;
        }
    }

    public T Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }
}
