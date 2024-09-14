using System.Linq.Expressions;

namespace E_Commerce.Domain.Interfaces;

/// <summary>
/// Interface for a generic repository providing basic CRUD operations on entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">Type of entity.</typeparam>
public interface IBaseRepository<T> where T : class
{
    /// <summary>
    /// Retrieves all entities of type <typeparamref name="T"/> from the database.
    /// </summary>
    /// <returns>An IEnumerable of entities of type <typeparamref name="T"/>.</returns>
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all entities of type <typeparamref name="T"/> from the database with specified navigation properties included.
    /// </summary>
    /// <param name="includes">Array of navigation properties to include.</param>
    /// <returns>An IEnumerable of entities.</returns>
    Task<IEnumerable<T>> GetAllAsync(string[] includes, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves entity of type <typeparamref name="T"/> based on a specified Guid.
    /// </summary>
    /// <returns>The first entity that matches the specified predicate.</returns>
    /// 
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves entity of type <typeparamref name="T"/> based on a specified Guid.
    /// </summary>
    /// <param name="includes">Array of navigation properties to include.</param>
    /// <returns>The first entity that matches the specified predicate.</returns>
    /// 
    Task<IEnumerable<T?>> GetByAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all entities of type <typeparamref name="T"/> based on a specified predicate, with specified navigation properties included.
    /// </summary>
    /// <param name="expression">The predicate to match the entity this should filter using  <typeparamref name="T"/> Id.</param>
    /// <param name="includes">Array of navigation properties to include.</param>
    /// <returns>The first entity that matches the specified predicate.</returns>
    Task<IEnumerable<T?>> GetByAsync(Expression<Func<T, bool>> expression, string[] includes, CancellationToken cancellationToken = default);
    /// <summary>
    /// Adds a new entity of type <typeparamref name="T"/> to the DataBase.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The added entity.</returns>
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing entity of type <typeparamref name="T"/> in the DataBase.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The updated entity.</returns>
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an existing entity of type <typeparamref name="T"/> from the DataBase.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>The deleted entity.</returns>
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
}
