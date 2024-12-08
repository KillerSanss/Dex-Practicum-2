using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация Drug для базы данных
/// </summary>
public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    /// <summary>
    /// Метод конфигурации
    /// </summary>
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        builder.ToTable(nameof(Drug));
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<BaseEntity>(nameof(BaseEntity.Id)));

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("name")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<Drug>(nameof(Drug.Name)));

        builder.Property(p => p.Manufacturer)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("manufacturer")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<Drug>(nameof(Drug.Manufacturer)));
        
        builder.Property(p => p.CountryCodeId)
            .IsRequired()
            .HasColumnName("country_code_id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<Drug>(nameof(Drug.CountryCodeId)));
        
        builder.HasMany(p => p.DrugItems)
            .WithOne(p => p.Drug)
            .HasForeignKey(p => p.DrugId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}