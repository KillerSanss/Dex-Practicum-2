using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;
using Xunit;
using Address = Domain.ValueObjects.Address;

namespace Tests.DrugStoreTests;

/// <summary>
/// Негативные тесты для сущности DrugStore
/// </summary>
public class DrugStoreNegativeTests
{
    public static IEnumerable<object[]> TestDrugStoreValidationExceptionData = NegativeTestsDataGenerator.GetDrugStoreValidationExceptionProperties();
    
    /// <summary>
    /// Проверка, что у сущности DrugStore выбрасывается ValidationException.
    /// </summary>
    /// <param name="drugNetwork">Аптечная сеть.</param>
    /// <param name="number">Номер.</param>
    /// <param name="address">Адрес.</param>
    /// <param name="phone">Номер телефона.</param>
    [Theory]
    [MemberData(nameof(TestDrugStoreValidationExceptionData))]
    public void Add_DrugStoreProperties_ThrowValidationException(
        string drugNetwork,
        int number,
        Address address,
        string phone)
    {
        // Act
        var action = () => new DrugStore(drugNetwork, number, address, phone);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}