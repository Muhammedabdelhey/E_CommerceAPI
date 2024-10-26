namespace E_Commerce.Infrastructure.Data.Repositories;

public class BaseRepository<T>(ApplicationDbContext context) : IBaseRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(string[] includes, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _context.Set<T>();
        foreach (string include in includes)
        {
            query = query.Include(include);
        }
        return await query.AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync(id, cancellationToken);
    }
    public async Task<T?> GetByIdAsync(Guid id, string[] includes, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _context.Set<T>();

        foreach (string include in includes)
        {
            query = query.Include(include);
        }
        return await query.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public virtual async Task<IEnumerable<T?>> GetByAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        IQueryable<T> entity = _context.Set<T>().Where(expression);
        return await entity.ToListAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<T?>> GetByAsync(Expression<Func<T, bool>> expression, string[] includes, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _context.Set<T>();
        foreach (string include in includes)
        {
            query = query.Include(include);
        }
        query = query.Where(expression);
        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}