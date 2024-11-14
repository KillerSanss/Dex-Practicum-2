using Domain.Entities;
using FluentValidation;

namespace Domain.Validation.Validators;

/// <summary>
/// Валидация любимого лекарства
/// </summary>
public class FavouriteDrugValidator : AbstractValidator<FavouriteDrug>
{
    public FavouriteDrugValidator()
    {
        RuleFor(d => d.ProfileId)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);

        RuleFor(d => d.Profile)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);

        RuleFor(d => d.DrugId)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
        
        RuleFor(d => d.Drug)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
    }
}