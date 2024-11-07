using Bogus;
using Domain.Entities;

namespace Tests.Generators;

/// <summary>
/// Генератор сущности Country для тестов
/// </summary>
public abstract class CountryGenerator
{
    private static readonly Faker<Country> Faker = new Faker<Country>()
        .CustomInstantiator(f => new Country(
            f.Random.String2(10),
            f.PickRandom(Country.ValidCountryCodes.ToList())
        ));
    
    /// <summary>
    /// Генерация страны
    /// </summary>
    /// <returns>Страна.</returns>
    public static Country GenerateCountry()
    {
        return Faker.Generate();
    }
}