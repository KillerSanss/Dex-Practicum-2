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
    public string House { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="city">Город.</param>
    /// <param name="street">Улица.</param>
    /// <param name="house">Дом.</param>
    public Address(string city, string street, string house)
    {
        City = city;
        Street = street;
        House = house;
    }
}