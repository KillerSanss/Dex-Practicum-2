using Bogus;
using Domain.Entities;
using FluentAssertions;
using Tests.Generators;
using Xunit;

namespace Tests.DrugItemTests;

/// <summary>
/// Позитивные тесты для сущности DrugItem
/// </summary>
public class DrugItemPositiveTests
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Проверка, что у сущности DrugItem корректно создается экземпляр
    /// </summary>
    [Fact]
    public void Add_DrugItem_ReturnNewDrugItem()
    {
        // Arrange
        var drug = DrugGenerator.GenerateDrug();
        var drugId = drug.Id;
        var drugStore = DrugStoreGenerator.GenerateDrugStore();
        var drugStoreId = drugStore.Id;
        var price = Math.Round(_faker.Random.Decimal(), 2);
        var amount = _faker.Random.Int(0, 10000);
        
        // Act
        var drugItem = new DrugItem(drugId, drug, drugStoreId, drugStore, price, amount);

        // Assert
        drugItem.DrugId.Should().Be(drugId);
        drugItem.Drug.Should().Be(drug);
        drugItem.DrugStore.Should().Be(drugStore);
        drugItem.DrugStoreId.Should().Be(drugStoreId);
        drugItem.Price.Should().Be(price);
        drugItem.Amount.Should().Be(amount);
    }
}