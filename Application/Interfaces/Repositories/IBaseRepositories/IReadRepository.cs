using Domain.Entities;
using Microsoft.AspNetCore.OData.Query;

namespace Application.Interfaces.Repositories.IBaseRepositories;

/// <summary>
/// Репозиторий чтения
/// </summary>
public interface IReadRepository<TEntity>
{
    /// <summary>
    /// Получение по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Сущность.</returns>
    public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получение всех
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список сущностей.</returns>
    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получение запроса с помощью OData
    /// </summary>
    /// <param name="queryOptions">Опции.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Запрос.</returns>
    public Task<IQueryable<TEntity>> GetQueryableAsync(ODataQueryOptions<TEntity> queryOptions, CancellationToken cancellationToken = default);
}