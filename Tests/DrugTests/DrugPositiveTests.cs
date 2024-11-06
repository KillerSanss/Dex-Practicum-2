using Bogus;
using Domain.Entities;
using FluentAssertions;
using Tests.Generators;
using Xunit;

namespace Tests.DrugTests;

/// <summary>
/// Позитивные тесты для сущности Drug
/// </summary>
public class DrugPositiveTests
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Проверка, что у сущности Drug корректно создается экземпляр
    /// </summary>
    [Fact]
    public void Add_Drug_ReturnNewDrug()
    {
        // Arrange
        var name = _faker.Random.String2(10);
        var manufacturer = _faker.Random.String2(10);
        var country = CountryGenerator.GenerateCountry();
        var countryCodeId = country.Code;
        
        // Act
        var drug = new Drug(name, manufacturer, countryCodeId, country);

        // Assert
        drug.Name.Should().Be(name);
        drug.Manufacturer.Should().Be(manufacturer);
        drug.CountryCodeId.Should().Be(countryCodeId);
        drug.Country.Should().Be(country);
    }
}