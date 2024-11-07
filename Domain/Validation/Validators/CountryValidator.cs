using Domain.Entities;
using FluentValidation;

namespace Domain.Validation.Validators;

public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(2).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(100).WithMessage(ValidationMessages.MaximumLengthError)
            .Matches(RegexPatterns.LettersPattern).WithMessage(ValidationMessages.OnlyLettersError);

        RuleFor(d => d.Code)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .Length(2,2).WithMessage(ValidationMessages.StrictLengthError)
            .Must(code => !string.IsNullOrEmpty(code)
                          && code.All(char.IsUpper)
                          && code.All(char.IsLetter)
                          && IsValidCountryCode(code)).WithMessage(ValidationMessages.CountryCodeError);
    }
    
    private static bool IsValidCountryCode(string code)
    {
        return Country.ValidCountryCodes.Contains(code);
    }
}