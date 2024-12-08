using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация Country для базы данных
/// </summary>
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    /// <summary>
    /// Метод конфигурации
    /// </summary>
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(nameof(Country));
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<BaseEntity>(nameof(BaseEntity.Id)));
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<Country>(nameof(Country.Name)));
        
        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(2)
            .HasColumnName("code")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<Country>(nameof(Country.Code)));
    }
}