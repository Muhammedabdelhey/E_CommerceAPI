using E_Commerce.Domain.Interfcases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using E_Commerce.Infrastructure.Data;
namespace E_Commerce.Infrastructure.Repositories;

public class BaseRepository<T>(ApplicationDbContext context) : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(string[] includes)
    {
        IQueryable<T> query = _context.Set<T>();
        foreach (string include in includes)
        {
            query = query.Include(include);
        }
        return await query.ToListAsync();
    }

    public virtual async Task<IEnumerable<T?>> GetByAsync(Expression<Func<T, bool>> expression)
    {
        IQueryable<T> entity = _context.Set<T>().Where(expression);
        return await entity.ToListAsync();
    }

    public virtual async Task<IEnumerable<T?>> GetByAsync(Expression<Func<T, bool>> expression, string[] includes)
    {
        IQueryable<T> query = _context.Set<T>();
        foreach (string include in includes)
        {
            query = query.Include(include);
        }
        query = query.Where(expression);
        return await query.ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}