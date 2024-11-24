using Bogus;
using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Tests.UserProfileTests;

/// <summary>
/// Позитивные тесты для сущности UserProfile
/// </summary>
public class UserProfilePositiveTests
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Проверка, что у сущности UserProfile корректно создается экземпляр
    /// </summary>
    [Fact]
    public void Add_UserProfile_ReturnProfile()
    {
        // Arrange
        var externalId = _faker.Random.Int(1000000, 9999999).ToString();
        var email = new Email(_faker.Internet.Email());
        
        // Act
        var userProfile = new UserProfile(externalId, email);

        // Assert
        userProfile.ExternalId.Should().Be(externalId);
        userProfile.Email.Should().Be(email);
    }
}