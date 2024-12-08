using Domain.Entities;
using Infrastructure.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Dal;

/// <summary>
/// Контекст базы данных
/// </summary>
public class DrugStoreDbContext : DbContext
{
    private readonly DatabaseSettings _options;
    
    /// <summary>
    /// Сущность профиля
    /// </summary>
    public DbSet<UserProfile> UserProfiles { get; init; }
    
    /// <summary>
    /// Сущность лекарства
    /// </summary>
    public DbSet<Drug> Drugs { get; init; }
    
    /// <summary>
    /// Сущность аптеки
    /// </summary>
    public DbSet<DrugStore> DrugStores { get; init; }
    
    /// <summary>
    /// Сущность страны
    /// </summary>
    public DbSet<Country> Countries { get; init; }
    
    /// <summary>
    /// Служебная таблица связи лекарства и магазина
    /// </summary>
    public DbSet<DrugItem> DrugItems { get; init; }
    
    /// <summary>
    /// Сущность любимого лекарства
    /// </summary>
    public DbSet<FavouriteDrug> FavouriteDrugs { get; init; }
    
    /// <summary>
    /// Конструктор с получением настроек базы данных
    /// </summary>
    public DrugStoreDbContext(IOptions<DatabaseSettings> options)
    {
        _options = options.Value;
    }
    
    /// <summary>
    /// Пустой конструктор для EF
    /// </summary>
    public DrugStoreDbContext()
    {
    }
    
    /// <summary>
    /// OnConfiguring
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseNpgsql(_options.ConnectionString, options =>
        {
            options.CommandTimeout(_options.CommandTimeout);
        });
    }

    /// <summary>
    /// Метод применения конфигураций
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DrugStoreDbContext).Assembly);
    }
}