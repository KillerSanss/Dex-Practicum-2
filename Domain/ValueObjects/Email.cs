using Domain.Validation.Validators;
using FluentValidation;

namespace Domain.ValueObjects;

/// <summary>
/// Электронная почта
/// </summary>
public class Email
{
    /// <summary>
    /// Почта
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="value">Почта.</param>
    public Email(string value)
    {
        Value = value;
        
        Validate();
    }
    
    private void Validate()
    {
        var validator = new EmailValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}