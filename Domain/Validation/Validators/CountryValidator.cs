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
            .MaximumLength(20).WithMessage(ValidationMessages.MaximumLengthError);

        RuleFor(d => d.Code)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
    }
}