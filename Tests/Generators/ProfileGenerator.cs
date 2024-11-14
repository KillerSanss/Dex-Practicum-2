using Bogus;
using Domain.Entities;
using Domain.ValueObjects;

namespace Tests.Generators;

/// <summary>
/// Генератор сущности Profile для тестов
/// </summary>
public class ProfileGenerator
{
    private static readonly Faker<Profile> Faker = new Faker<Profile>()
        .CustomInstantiator(f => new Profile(
            f.Random.Int(1000000, 9999999).ToString(),
            new Email(f.Internet.Email())
        ));
    
    /// <summary>
    /// Генерация профиля
    /// </summary>
    /// <returns>Профиль.</returns>
    public static Profile GenerateProfile()
    {
        return Faker.Generate();
    }
}