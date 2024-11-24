using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;
using Xunit;

namespace Tests.DrugItemTests;

/// <summary>
/// Негативные тесты для сущности DrugItem
/// </summary>
public class DrugItemNegativeTests
{
    public static IEnumerable<object[]> TestDrugItemValidationExceptionData = NegativeTestsDataGenerator.GetDrugItemValidationExceptionProperties();
    
    /// <summary>
    /// Проверка, что у сущности DrugItem выбрасывается ValidationException.
    /// </summary>
    /// <param name="drugId">Идентификатор лекарства.</param>
    /// <param name="drug">Лекарство.</param>
    /// <param name="drugStoreId">Идентификатор аптеки.</param>
    /// <param name="drugStore">Аптека.</param>
    /// <param name="price">Цена.</param>
    /// <param name="amount">Кол-во.</param>
    [Theory]
    [MemberData(nameof(TestDrugItemValidationExceptionData))]
    public void Add_DrugStoreProperties_ThrowValidationException(
        Guid drugId,
        Drug drug,
        Guid drugStoreId,
        DrugStore drugStore,
        decimal price,
        int amount)
    {
        // Act
        var action = () => new DrugItem(drugId, drug, drugStoreId, drugStore, price, amount);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}