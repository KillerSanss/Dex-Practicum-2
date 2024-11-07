using Bogus;
using Domain.ValueObjects;

namespace Tests.Generators;

/// <summary>
/// Генерация данных для негативных тестов
/// </summary>
public class NegativeTestsDataGenerator
{
    private static readonly Faker Faker = new();
    
    /// <summary>
    /// Генерация данных для исключения ValidationException у сущности Drug
    /// </summary>
    public static IEnumerable<object[]> GetDrugValidationExceptionProperties()
    {
        var country = CountryGenerator.GenerateCountry();
        
        return new List<object[]>
        {
            new object[] {null, Faker.Random.String2(10), country.Code, country },
            new object[] {Faker.Random.String2(10), null, country.Code, country },
            new object[] {Faker.Random.String2(10), Faker.Random.String2(10), null, country },
            new object[] {Faker.Random.String2(10), Faker.Random.String2(10), country.Code, null }
        };
    }
    
    /// <summary>
    /// Генерация данных для исключения ValidationException у сущности Country
    /// </summary>
    public static IEnumerable<object[]> GetCountryValidationExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {null, Faker.Random.Int(1, 1000).ToString() },
            new object[] {Faker.Random.String2(10), null }
        };
    }
    
    /// <summary>
    /// Генерация данных для исключения ValidationException у сущности DrugStore
    /// </summary>
    public static IEnumerable<object[]> GetDrugStoreValidationExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {null, Faker.Random.Int(1, 1000), new Address(Faker.Address.City(), Faker.Address.StreetName(), Faker.Random.Int(1, 100), Faker.Random.Int(10000, 999999)), Faker.Phone.PhoneNumber("373########") },
            new object[] {Faker.Random.String2(10), -1, new Address(Faker.Address.City(), Faker.Address.StreetName(), Faker.Random.Int(1, 100), Faker.Random.Int(10000, 999999)), Faker.Phone.PhoneNumber("373########") },
            new object[] {Faker.Random.String2(10), Faker.Random.Int(1, 1000), null, Faker.Phone.PhoneNumber("373########") },
            new object[] {Faker.Random.String2(10), Faker.Random.Int(1, 1000), new Address(Faker.Address.City(), Faker.Address.StreetName(), Faker.Random.Int(1, 100), Faker.Random.Int(10000, 999999)), null }
        };
    }
    
    /// <summary>
    /// Генерация данных для исключения ValidationException у сущности DrugItem
    /// </summary>
    public static IEnumerable<object[]> GetDrugItemValidationExceptionProperties()
    {
        var drug = DrugGenerator.GenerateDrug();
        var drugStore = DrugStoreGenerator.GenerateDrugStore();
        
        return new List<object[]>
        {
            new object[] {null, drug, drugStore.Id, drugStore, Faker.Random.Decimal(1), Faker.Random.Int(1, 1000) },
            new object[] {drug.Id, null, drugStore.Id, drugStore, Faker.Random.Decimal(1), Faker.Random.Int(1, 1000) },
            new object[] {drug.Id, drug, null, drugStore, Faker.Random.Decimal(1), Faker.Random.Int(1, 1000) },
            new object[] {drug.Id, drug, drugStore.Id, null, Faker.Random.Decimal(1), Faker.Random.Int(1, 1000) },
            new object[] {drug.Id, drug, drugStore.Id, drugStore, -1, Faker.Random.Int(1, 1000) },
            new object[] {drug.Id, drug, drugStore.Id, drugStore, Faker.Random.Decimal(1), -1 }
        };
    }
    
    /// <summary>
    /// Генерация данных для исключения ValidationException у значимого объекта Address
    /// </summary>
    public static IEnumerable<object[]> GetAddressValidationExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {null, Faker.Address.StreetName(), Faker.Random.Int(1, 100), Faker.Random.Int(10000, 999999) },
            new object[] {Faker.Address.City(), null, Faker.Random.Int(1, 100), Faker.Random.Int(10000, 999999) },
            new object[] {Faker.Address.City(), Faker.Address.StreetName(), null, Faker.Random.Int(10000, 999999) },
            new object[] {Faker.Address.City(), Faker.Address.StreetName(), Faker.Random.Int(1, 100), null }
        };
    }
}