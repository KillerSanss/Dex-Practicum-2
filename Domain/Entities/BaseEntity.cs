namespace Domain.Entities;

/// <summary>
/// Базовая сущность
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    private Guid Id { get; set; }
    
    /// <summary>
    /// Установка идентификатора
    /// </summary>
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
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