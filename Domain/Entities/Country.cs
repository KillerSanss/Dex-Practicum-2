using Domain.Validation.Validators;
using FluentValidation;

namespace Domain.Entities;

/// <summary>
/// Сущность страны
/// </summary>
public class Country : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Код страны
    /// </summary>
    public string Code { get; set; }
    
    /// <summary>
    /// Список лекарств
    /// </summary>
    public ICollection<Drug> Drugs { get; set; } = new List<Drug>();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Название.</param>
    /// <param name="code">Код страны.</param>
    public Country(
        string name,
        string code)
    {
        Name = name;
        Code = code;

        Validate();
    }
    
    /// <summary>
    /// Метод обновления Drug
    /// </summary>
    /// <param name="name">Название.</param>
    /// <param name="code">Код страны.</param>
    public void Update(
        string name,
        string code)
    {
        Name = name;
        Code = code;

        Validate();
    }
    
    private void Validate()
    {
        var validator = new CountryValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    
    /// <summary>
    /// Список ISO кодов стран
    /// </summary>
    public static readonly HashSet<string> ValidCountryCodes =
    [
        "US", "RU", "GB", "DE", "FR", "IN", "CA", "BR", "JP", "AU",
        "CN", "ZA", "IT", "ES", "PL", "KR", "MX", "NG", "AR", "SE",
        "FI", "NO", "TR", "EG", "KR", "NL", "CH", "SE", "AT", "PT",
        "DK", "GR", "FI", "BE", "CO", "TH", "PH", "SG", "MY", "UA"
    ];
}