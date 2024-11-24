using Bogus;
using Domain.Entities;
using Domain.ValueObjects;

namespace Tests.Generators;

/// <summary>
/// Генератор сущности UserProfile для тестов
/// </summary>
public class UserProfileGenerator
{
    private static readonly Faker<UserProfile> Faker = new Faker<UserProfile>()
        .CustomInstantiator(f => new UserProfile(
            f.Random.Int(1000000, 9999999).ToString(),
            new Email(f.Internet.Email())
        ));
    
    /// <summary>
    /// Генерация профиля
    /// </summary>
    /// <returns>Профиль.</returns>
    public static UserProfile GenerateUserProfile()
    {
        return Faker.Generate();
    }
}