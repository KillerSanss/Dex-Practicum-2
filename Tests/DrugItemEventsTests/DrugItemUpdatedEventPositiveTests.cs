using Domain.DomainEvents;
using FluentAssertions;
using Tests.Generators;
using Xunit;

namespace Tests.DrugItemEventsTests;

/// <summary>
/// Позитивные тесты для события DrugItemUpdatedEvent
/// </summary>
public class DrugItemUpdatedEventPositiveTests
{
    /// <summary>
    /// Проверка, что новое событие DrugItemUpdatedEvent добавляется в список
    /// </summary>
    [Fact]
    public void UpdateDrugAmount_ShouldAddEvent()
    {
        // Arrange
        var drugItem = DrugItemGenerator.GenerateDrugItem();

        // Act
        drugItem.UpdateDrugAmount(10);
        var domainEvent = drugItem.GetDomainEvents().OfType<DrugItemUpdatedEvent>().First();

        // Assert
        domainEvent.NewAmount.Should().Be(10);
        drugItem.GetDomainEvents().Should().ContainSingle(e => e is DrugItemUpdatedEvent);
    }
}