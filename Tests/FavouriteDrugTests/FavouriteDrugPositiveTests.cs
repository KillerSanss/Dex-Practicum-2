using Domain.Entities;
using FluentAssertions;
using Tests.Generators;
using Xunit;

namespace Tests.FavouriteDrugTests;

/// <summary>
/// Позитивные тесты для сущности FavouriteDrug
/// </summary>
public class FavouriteDrugPositiveTests
{
    /// <summary>
    /// Проверка, что у сущности FavouriteDrug корректно создается экземпляр
    /// </summary>
    [Fact]
    public void Add_FavouriteDrug_ReturnNewFavouriteDrug()
    {
        // Arrange
        var userProfile = UserProfileGenerator.GenerateUserProfile();
        var profileId = userProfile.Id;
        var drug = DrugGenerator.GenerateDrug();
        var drugId = drug.Id;
        var drugStore = DrugStoreGenerator.GenerateDrugStore();
        var drugStoreId = drugStore.Id;
        
        // Act
        var favouriteDrug = new FavouriteDrug(profileId, userProfile, drugId, drug, drugStoreId, drugStore);

        // Assert
        favouriteDrug.ProfileId.Should().Be(profileId);
        favouriteDrug.UserProfile.Should().Be(userProfile);
        favouriteDrug.DrugId.Should().Be(drugId);
        favouriteDrug.Drug.Should().Be(drug);
        favouriteDrug.DrugStoreId.Should().Be(drugStoreId);
        favouriteDrug.DrugStore.Should().Be(drugStore);
    }
}