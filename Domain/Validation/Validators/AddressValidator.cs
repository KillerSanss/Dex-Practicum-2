using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validation.Validators;

/// <summary>
/// Валидация адреса
/// </summary>
public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(d => d.City)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(2).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(50).WithMessage(ValidationMessages.MaximumLengthError);
        
        RuleFor(d => d.Street)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(3).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(100).WithMessage(ValidationMessages.MaximumLengthError);

        RuleFor(d => d.House)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .GreaterThan(0).WithMessage(ValidationMessages.NegativeOrZeroNumberError);
        
        RuleFor(d => d.PostalCode)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .GreaterThanOrEqualTo(10000).WithMessage(ValidationMessages.MinimumLengthError)
            .LessThanOrEqualTo(999999).WithMessage(ValidationMessages.MaximumLengthError);
    }
}