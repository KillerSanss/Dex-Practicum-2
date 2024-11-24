using Domain.Entities;

namespace Application.Interfaces.Repositories.IBaseRepositories;

/// <summary>
/// Репозиторий записи
/// </summary>
public interface IWriteRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Репозиторий для операций чтения
    /// </summary>
    public IReadRepository<TEntity> ReadRepository { get; }

    /// <summary>
    /// Добавление
    /// </summary>
    /// <param name="entity">Сущность на добавление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="entity">Сущность на обновление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}