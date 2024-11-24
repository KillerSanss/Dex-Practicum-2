using Domain.Entities;
using FluentValidation;

namespace Domain.Validation.Validators;

/// <summary>
/// Валидация лекарства
/// </summary>
public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(2).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(150).WithMessage(ValidationMessages.MaximumLengthError)
            .Matches(RegexPatterns.NoSpecialSymbolsPattern).WithMessage(ValidationMessages.SpecialSymbolsError);
        
        RuleFor(d => d.Manufacturer)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(2).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(100).WithMessage(ValidationMessages.MaximumLengthError);

        RuleFor(d => d.CountryCodeId)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
        
        RuleFor(d => d.Country)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
    }
}