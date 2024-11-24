using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;
using Xunit;

namespace Tests.UserProfileTests;

/// <summary>
/// Позитивные тесты для сущности UserProfile
/// </summary>
public class UserProfileNegativeTests
{
    public static IEnumerable<object[]> TestUserProfileValidationExceptionData = NegativeTestsDataGenerator.GetUserProfileValidationExceptionProperties();
    
    /// <summary>
    /// Проверка, что у сущности UserProfile выбрасывается ValidationException.
    /// </summary>
    /// <param name="externalId">Внешний идентификатор (телеграм).</param>
    /// <param name="email">Электронная почта.</param>
    [Theory]
    [MemberData(nameof(TestUserProfileValidationExceptionData))]
    public void Add_UserProfileProperties_ThrowValidationException(
        string externalId,
        Email email)
    {
        // Act
        var action = () => new UserProfile(externalId, email);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}