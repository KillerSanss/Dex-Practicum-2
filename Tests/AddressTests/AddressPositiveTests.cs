using Bogus;
using FluentAssertions;
using Xunit;
using Address = Domain.ValueObjects.Address;

namespace Tests.AddressTests;

/// <summary>
/// Позитивные тесты для значимого объекта Address
/// </summary>
public class AddressPositiveTests
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Проверка, что у значимого объекта Address корректно создается экземпляр
    /// </summary>
    [Fact]
    public void Add_Country_ReturnNewCountry()
    {
        // Arrange
        var city = _faker.Address.City();
        var street = _faker.Address.StreetName();
        var house = _faker.Random.Int(1, 100);
        var postalCode = _faker.Random.Int(10000, 999999);
        
        // Act
        var address = new Address(city, street, house, postalCode);
        
        // Assert
        address.City.Should().Be(city);
        address.Street.Should().Be(street);
        address.House.Should().Be(house);
        address.PostalCode.Should().Be(postalCode);
    }
}