using Bogus;
using Domain.Entities;

namespace Tests.Generators;

/// <summary>
/// Генератор сущности DrugItem для тестов
/// </summary>
public class DrugItemGenerator
{
    private static Drug drug = DrugGenerator.GenerateDrug();
    private static DrugStore drugStore = DrugStoreGenerator.GenerateDrugStore();
    
    private static readonly Faker<DrugItem> Faker = new Faker<DrugItem>()
        .CustomInstantiator(f => new DrugItem(
            drug.Id,
            drug,
            drugStore.Id,
            drugStore,
            Math.Round(f.Random.Decimal(), 2),
            f.Random.Int(0, 100)
        ));
    
    /// <summary>
    /// Генерация DrugItem
    /// </summary>
    /// <returns>DrugItem.</returns>
    public static DrugItem GenerateDrugItem()
    {
        return Faker.Generate();
    }
}