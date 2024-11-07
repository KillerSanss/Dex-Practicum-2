using Bogus;
using Domain.Entities;
using FluentAssertions;
using Xunit;
using Address = Domain.ValueObjects.Address;

namespace Tests.DrugStoreTests;

/// <summary>
/// Позитивные тесты для сущности DrugStore
/// </summary>
public class DrugStorePositiveTests
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Проверка, что у сущности DrugStore корректно создается экземпляр
    /// </summary>
    [Fact]
    public void Add_DrugStore_ReturnNewDrugStore()
    {
        // Arrange
        var drugNetwork = _faker.Random.String2(10);
        var number = _faker.Random.Int(1, 100);
        var address = new Address(_faker.Address.City(), _faker.Address.StreetName(),
            _faker.Random.Int(1, 100), _faker.Random.Int(10000, 999999));
        var phone = _faker.Phone.PhoneNumber("373########");
        
        // Act
        var drugStore = new DrugStore(drugNetwork, number, address, phone);

        // Assert
        drugStore.DrugNetwork.Should().Be(drugNetwork);
        drugStore.Number.Should().Be(number);
        drugStore.Address.Should().Be(address);
        drugStore.Phone.Should().Be(phone);
    }
}