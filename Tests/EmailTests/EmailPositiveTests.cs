using Bogus;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Tests.EmailTests;

/// <summary>
/// Позитивные тесты для значимого объекта Email
/// </summary>
public class EmailPositiveTests
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Проверка, что у значимого объекта Email корректно создается экземпляр
    /// </summary>
    [Fact]
    public void Add_Email_ReturnNewEmail()
    {
        // Arrange
        var value = _faker.Internet.Email();
        
        // Act
        var email = new Email(value);
        
        // Assert
        email.Value.Should().Be(value);
    }
}