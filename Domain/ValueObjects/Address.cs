using Domain.Validation.Validators;
using FluentValidation;

namespace Domain.ValueObjects;

/// <summary>
/// Адрес
/// </summary>
public class Address
{
    /// <summary>
    /// Город
    /// </summary>
    public string City { get; private set; }
    
    /// <summary>
    /// Улица
    /// </summary>
    public string Street { get; private set; }
    
    /// <summary>
    /// Дом
    /// </summary>
    public int House { get; private set; }
    
    /// <summary>
    /// Почтовый индекс
    /// </summary>
    public int PostalCode { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="city">Город.</param>
    /// <param name="street">Улица.</param>
    /// <param name="house">Дом.</param>
    /// <param name="postalCode">Почтовый индекс.</param>
    public Address(string city, string street, int house, int postalCode)
    {
        City = city;
        Street = street;
        House = house;
        PostalCode = postalCode;
        
        Validate();
    }
    
    private void Validate()
    {
        var validator = new AddressValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}