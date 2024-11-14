using Domain.Interfaces;
using Domain.Validation.Validators;
using FluentValidation;

namespace Domain.DomainEvents;

/// <summary>
/// Доменное событие на обновление DrugItem
/// </summary>
public class DrugItemUpdatedEvent : IDomainEvent
{
    /// <summary>
    /// Идентификатор DrugItem
    /// </summary>
    public Guid DrugItemId { get; }
    
    /// <summary>
    /// Новое количество
    /// </summary>
    public double NewAmount { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugItemId">Идентификатор DrugItem.</param>
    /// <param name="newAmount">Новое кол-во.</param>
    public DrugItemUpdatedEvent(Guid drugItemId, double newAmount)
    {
        DrugItemId = drugItemId;
        NewAmount = newAmount;

        Validate();
    }
    
    private void Validate()
    {
        var validator = new DrugItemUpdatedEventValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}