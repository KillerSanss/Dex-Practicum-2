using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;
using Xunit;

namespace Tests.ProfileTests;

public class ProfileNegativeTests
{
    public static IEnumerable<object[]> TestProfileValidationExceptionData = NegativeTestsDataGenerator.GetProfileValidationExceptionProperties();
    
    /// <summary>
    /// Проверка, что у сущности Profile выбрасывается ValidationException.
    /// </summary>
    /// <param name="externalId">Внешний идентификатор (телеграм).</param>
    /// <param name="email">Электронная почта.</param>
    [Theory]
    [MemberData(nameof(TestProfileValidationExceptionData))]
    public void Add_DrugProperties_ThrowValidationException(
        string externalId,
        Email email)
    {
        // Act
        var action = () => new Profile(externalId, email);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}