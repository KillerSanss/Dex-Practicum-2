using Bogus;
using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Tests.CountryTests;

/// <summary>
/// Позитивные тесты для сущности Country
/// </summary>
public class CountryPositiveTests
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Проверка, что у сущности Country корректно создается экземпляр
    /// </summary>
    [Fact]
    public void Add_Country_ReturnNewCountry()
    {
        // Arrange
        var name = _faker.Random.String2(10);
        var code = _faker.PickRandom(Country.ValidCountryCodes.ToList());
        
        // Act
        var country = new Country(name, code);

        // Assert
        country.Name.Should().Be(name);
        country.Code.Should().Be(code);
    }
}