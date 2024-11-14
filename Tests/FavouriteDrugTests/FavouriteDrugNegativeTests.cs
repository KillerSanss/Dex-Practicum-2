using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;
using Xunit;

namespace Tests.FavouriteDrugTests;

/// <summary>
/// Негативные тесты для сущности FavouriteDrug
/// </summary>
public class FavouriteDrugNegativeTests
{
    public static IEnumerable<object[]> TestFavouriteDrugValidationExceptionData = NegativeTestsDataGenerator.GetFavouriteDrugValidationExceptionProperties();
    
    /// <summary>
    /// Проверка, что у сущности FavouriteDrug выбрасывается ValidationException.
    /// </summary>
    /// <param name="profileId">Идентификатор профиля.</param>
    /// <param name="profile">Профиль.</param>
    /// <param name="drugId">Идентификатор лекарства.</param>
    /// <param name="drug">Лекарство.</param>
    [Theory]
    [MemberData(nameof(TestFavouriteDrugValidationExceptionData))]
    public void Add_FavouriteDrugProperties_ThrowValidationException(
        Guid profileId,
        Profile profile,
        Guid drugId,
        Drug drug)
    {
        // Arrange
        var drugStore = DrugStoreGenerator.GenerateDrugStore();
        var drugStoreId = drugStore.Id;
        
        // Act
        var action = () => new FavouriteDrug(profileId, profile, drugId, drug, drugStoreId, drugStore);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}