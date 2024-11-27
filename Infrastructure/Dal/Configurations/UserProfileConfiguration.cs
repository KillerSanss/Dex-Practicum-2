using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация UserProfile для базы данных
/// </summary>
public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    /// <summary>
    /// Метод конфигурации
    /// </summary>
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable(nameof(UserProfile));
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<BaseEntity>(nameof(BaseEntity.Id)));

        builder.Property(p => p.ExternalId)
            .IsRequired()
            .HasColumnName("external_id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<UserProfile>(nameof(UserProfile.ExternalId)));

        builder.OwnsOne(s => s.Email, email =>
        {
            email.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("email")
                .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<Email>(nameof(Email.Value)));
        });
        
        builder.HasMany(p => p.FavouriteDrugs)
            .WithOne(p => p.UserProfile)
            .HasForeignKey(p => p.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}