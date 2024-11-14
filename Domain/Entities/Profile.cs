using Domain.Validation.Validators;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Entities;

/// <summary>
/// Сущность профиля
/// </summary>
public class Profile : BaseEntity
{
    /// <summary>
    /// Внешний идентификатор (телеграм)
    /// </summary>
    public string ExternalId { get; set; }
    
    /// <summary>
    /// Электронная почта
    /// </summary>
    public Email Email { get; set; }
    
    /// <summary>
    /// Список FavouriteDrug у пользователя
    /// </summary>
    public ICollection<FavouriteDrug> FavouriteDrugs { get; set; } = new List<FavouriteDrug>();
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="externalId">Внешний идентификатор (телеграм).</param>
    /// <param name="email">Электронная почта.</param>
    public Profile(
        string externalId,
        Email email)
    {
        ExternalId = externalId;
        Email = email;
        
        Validate();
    }
    
    private void Validate()
    {
        var validator = new ProfileValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}