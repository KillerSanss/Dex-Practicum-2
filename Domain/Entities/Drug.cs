using Domain.Validation.Validators;
using FluentValidation;

namespace Domain.Entities;

/// <summary>
/// Сущность лекарства
/// </summary>
public class Drug : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Изготовитель
    /// </summary>
    public string Manufacturer { get; set; }
    
    /// <summary>
    /// Код страны - страна изготовитель
    /// </summary>
    public string CountryCodeId { get; set; }
    
    /// <summary>
    /// Навигационное поле для Country
    /// </summary>
    public Country Country { get; set; }
    
    /// <summary>
    /// Список связей DrugItem
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; set; } = new List<DrugItem>();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Название.</param>
    /// <param name="manufacturer">Изготовитель.</param>
    /// <param name="countryCodeId">Код страны - страна изготовитель.</param>
    /// <param name="country">Страна.</param>
    public Drug(
        string name,
        string manufacturer,
        string countryCodeId,
        Country country)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;
        Country = country;
        
        Validate();
    }
    
    /// <summary>
    /// Метод обновления Drug
    /// </summary>
    /// <param name="name">Название.</param>
    /// <param name="manufacturer">Изготовитель.</param>
    /// <param name="countryCodeId">Код страны - страна изготовитель.</param>
    /// <param name="country">Страна.</param>
    public void Update(
        string name,
        string manufacturer,
        string countryCodeId,
        Country country)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;
        Country = country;
        
        Validate();
    }

    private void Validate()
    {
        var validator = new DrugValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}