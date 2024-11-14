using Domain.Interfaces;

namespace Domain.Entities;

/// <summary>
/// Базовая сущность
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Список доменных событий
    /// </summary>
    private List<IDomainEvent> DomainEvents { get; set; } = new();
    
    /// <summary>
    /// Установка идентификатора
    /// </summary>
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    /// <summary>
    /// Добавление события в список
    /// </summary>
    /// <param name="domainEvent">Событие.</param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Получение списка событий
    /// </summary>
    /// <returns>Список событий.</returns>
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return DomainEvents.AsReadOnly();
    }

    /// <summary>
    /// Очистка событий
    /// </summary>
    public void ClearDomainEvents()
    {
        DomainEvents.Clear();
    }
    
    /// <summary>
    /// Переопределение метода Equals
    /// </summary>
    /// <param name="obj">Объект.</param>
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (obj is not BaseEntity entity)
            return false;

        if (Id != entity.Id)
            return false;

        if (this.GetHashCode() != entity.GetHashCode())
        {
            return false;
        }
        
        return true;
    }
    
    /// <summary>
    /// Переопределение метода GetHashCode
    /// </summary>
    /// <returns>Хэш-код.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    /// <summary>
    /// Переопределение оператора ==
    /// </summary>
    public static bool operator ==(BaseEntity? left, BaseEntity? right)
    {
        if (ReferenceEquals(left, right))
            return true;
    
        if (left is null || right is null)
            return false;
    
        return left.Equals(right);
    }

    /// <summary>
    /// Переопределение оператора !=
    /// </summary>
    public static bool operator !=(BaseEntity? left, BaseEntity? right)
    {
        return !(left == right);
    }
}