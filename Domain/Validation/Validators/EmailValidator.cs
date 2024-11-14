using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validation.Validators;

/// <summary>
/// Валидация электронной почты
/// </summary>
public class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(d => d.Value)
            .MaximumLength(255).WithMessage(ValidationMessages.MaximumLengthError)
            .Matches(RegexPatterns.EmailPattern).WithMessage(ValidationMessages.EmailError);
    }
}