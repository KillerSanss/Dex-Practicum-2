using Domain.DomainEvents;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;
using Xunit;

namespace Tests.DrugItemEventsTests;

/// <summary>
/// Негативные тесты для события DrugItemUpdatedEvent
/// </summary>
public class DrugItemUpdatedEventNegativeTests
{
    /// <summary>
    /// Проверка, что событие DrugItemUpdatedEvent выбрасывает ValidationException
    /// </summary>
    [Fact]
    public void UpdateDrugAmount_ShouldThrowValidationException()
    {
        // Arrange
        var drugItem = DrugItemGenerator.GenerateDrugItem();

        // Act
        var action = () => new DrugItemUpdatedEvent(drugItem.Id, -1);

        // Assert
        action.Should().Throw<ValidationException>();
        drugItem.GetDomainEvents().Should().BeEmpty();
    }
}