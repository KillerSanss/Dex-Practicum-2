using Domain.Entities;
using FluentValidation;

namespace Domain.Validation.Validators;

/// <summary>
/// Валидация профиля
/// </summary>
public class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        RuleFor(d => d.ExternalId)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);

        RuleFor(d => d.Email)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
    }
}