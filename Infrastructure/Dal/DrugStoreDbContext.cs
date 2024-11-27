using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal;

/// <summary>
/// Контекст базы данных
/// </summary>
public class DrugStoreDbContext : DbContext
{
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
    /// Конструктор
    /// </summary>
    public DrugStoreDbContext(DbContextOptions<DrugStoreDbContext> options) : base(options)
    {
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

        optionsBuilder.UseNpgsql(
            "User ID=postgres;Password=sans;Host=localhost;Port=5432;Database=DrugStore;");
    }

    /// <summary>
    /// Метод применения конфигураций
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DrugStoreDbContext).Assembly);
    }
}