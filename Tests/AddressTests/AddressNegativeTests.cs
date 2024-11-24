using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;
using Xunit;

namespace Tests.AddressTests;

/// <summary>
/// Негативные тесты для значимого объекта Address
/// </summary>
public class AddressNegativeTests
{
    public static IEnumerable<object[]> TestAddressValidationExceptionData = NegativeTestsDataGenerator.GetAddressValidationExceptionProperties();
    
    /// <summary>
    /// Проверка, что у значимого объекта Address выбрасывается ValidationException.
    /// </summary>
    /// <param name="city">Город.</param>
    /// <param name="street">Улица.</param>
    /// <param name="house">Номер дома.</param>
    /// <param name="postalCode">Почтовый индекс.</param>
    [Theory]
    [MemberData(nameof(TestAddressValidationExceptionData))]
    public void Add_DrugStoreProperties_ThrowValidationException(
        string city,
        string street,
        int house,
        int postalCode)
    {
        // Act
        var action = () => new Address(city, street, house, postalCode);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}