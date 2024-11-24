using Domain.DomainEvents;
using FluentValidation;

namespace Domain.Validation.Validators;

/// <summary>
/// Валидация для события DrugItemUpdatedEvent
/// </summary>
public class DrugItemUpdatedEventValidator : AbstractValidator<DrugItemUpdatedEvent>
{
    public DrugItemUpdatedEventValidator()
    {
        RuleFor(d => d.NewAmount)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.NegativeNumberError)
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessages.GreaterThenNumberError);
    }
}