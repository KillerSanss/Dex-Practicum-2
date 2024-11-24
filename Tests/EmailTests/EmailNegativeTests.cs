using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;
using Xunit;

namespace Tests.EmailTests;

/// <summary>
/// Негативные тесты для значимого объекта Email
/// </summary>
public class EmailNegativeTests
{
    public static IEnumerable<object[]> TestEmailValidationExceptionData = NegativeTestsDataGenerator.GetEmailValidationExceptionProperties();
    
    /// <summary>
    /// Проверка, что у значимого объекта Address выбрасывается ValidationException.
    /// </summary>
    /// <param name="value">Электронная почта.</param>
    [Theory]
    [MemberData(nameof(TestEmailValidationExceptionData))]
    public void Add_EmailProperties_ThrowValidationException(
        string value)
    {
        // Act
        var action = () => new Email(value);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}