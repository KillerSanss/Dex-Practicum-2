using Bogus;
using Domain.Entities;
using Domain.ValueObjects;

namespace Tests.Generators;

/// <summary>
/// Генератор сущности DrugStore для тестов
/// </summary>
public abstract class DrugStoreGenerator
{
    private static readonly Faker<DrugStore> Faker = new Faker<DrugStore>()
        .CustomInstantiator(f => new DrugStore(
            f.Random.String2(10),
            f.Random.Number(1, 1000),
            new Address(f.Address.City(), f.Address.StreetName(), f.Address.BuildingNumber()),
            f.Phone.PhoneNumber("373########")
        ));
    
    /// <summary>
    /// Генерация аптеки
    /// </summary>
    /// <returns>Аптека.</returns>
    public static DrugStore GenerateDrugStore()
    {
        return Faker.Generate();
    }
}