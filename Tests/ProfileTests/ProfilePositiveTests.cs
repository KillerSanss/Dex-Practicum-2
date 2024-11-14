using Bogus;
using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Tests.ProfileTests;

/// <summary>
/// Позитивные тесты для сущности Profile
/// </summary>
public class ProfilePositiveTests
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Проверка, что у сущности Profile корректно создается экземпляр
    /// </summary>
    [Fact]
    public void Add_Profile_ReturnProfile()
    {
        // Arrange
        var externalId = _faker.Random.Int(1000000, 9999999).ToString();
        var email = new Email(_faker.Internet.Email());
        
        // Act
        var profile = new Profile(externalId, email);

        // Assert
        profile.ExternalId.Should().Be(externalId);
        profile.Email.Should().Be(email);
    }
}