using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация FavouriteDrug для базы данных
/// </summary>
public class FavouriteDrugConfiguration : IEntityTypeConfiguration<FavouriteDrug>
{
    /// <summary>
    /// Метод конфигурации
    /// </summary>
    public void Configure(EntityTypeBuilder<FavouriteDrug> builder)
    {
        builder.ToTable(nameof(FavouriteDrug));

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<BaseEntity>(nameof(BaseEntity.Id)));
        
        builder.Property(p => p.ProfileId)
            .IsRequired()
            .HasColumnName("profile_id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<FavouriteDrug>(nameof(FavouriteDrug.ProfileId)));
        
        builder.Property(p => p.DrugId)
            .IsRequired()
            .HasColumnName("drug_id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<FavouriteDrug>(nameof(FavouriteDrug.DrugId)));
        
        builder.HasOne(p => p.Drug)
            .WithMany()
            .HasForeignKey(p => p.DrugId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.UserProfile)
            .WithMany()
            .HasForeignKey(p => p.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}