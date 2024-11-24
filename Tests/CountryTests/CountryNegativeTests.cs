using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;
using Xunit;

namespace Tests.CountryTests;

/// <summary>
/// Негативные тесты для сущности Country
/// </summary>
public class CountryNegativeTests
{
    public static IEnumerable<object[]> TestCountryValidationExceptionData = NegativeTestsDataGenerator.GetCountryValidationExceptionProperties();
    
    /// <summary>
    /// Проверка, что у сущности Country выбрасывается ValidationException.
    /// </summary>
    /// <param name="name">Название страны.</param>
    /// <param name="code">Код страны.</param>
    [Theory]
    [MemberData(nameof(TestCountryValidationExceptionData))]
    public void Add_DrugStoreProperties_ThrowValidationException(
        string name,
        string code)
    {
        // Act
        var action = () => new Country(name, code);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}