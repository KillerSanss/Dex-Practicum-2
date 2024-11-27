using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация DrugStore для базы данных
/// </summary>
public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    /// <summary>
    /// Метод конфигурации
    /// </summary>
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        builder.ToTable(nameof(DrugStore), tableBuilder =>
        {
            tableBuilder.HasCheckConstraint("CK_Number_GreaterThanZero", "[number] > 0");
            tableBuilder.HasCheckConstraint("CK_House_GreaterThanZero", "[house] > 0");
            tableBuilder.HasCheckConstraint("CK_PostalCode_Range", "[postal_code] >= 10000 AND [postal_code] <= 999999");
        });
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<BaseEntity>(nameof(BaseEntity.Id)));
        
        builder.Property(p => p.DrugNetwork)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("drug_network")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<DrugStore>(nameof(DrugStore.DrugNetwork)));
        
        builder.Property(p => p.Number)
            .IsRequired()
            .HasColumnName("number")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<DrugStore>(nameof(DrugStore.Number)));
        
        builder.OwnsOne(s => s.Address, address =>
        {
            address.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("city")
                .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<Address>(nameof(Address.City)));
            
            address.Property(p => p.Street)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("street")
                .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<Address>(nameof(Address.Street)));
            
            address.Property(p => p.House)
                .IsRequired()
                .HasColumnName("house")
                .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<Address>(nameof(Address.House)));
            
            address.Property(p => p.PostalCode)
                .IsRequired()
                .HasColumnName("postal_code")
                .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<Address>(nameof(Address.PostalCode)));
        });
        
        builder.Property(p => p.Phone)
            .IsRequired()
            .HasColumnName("phone")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<DrugStore>(nameof(DrugStore.Phone)));
        
        builder.HasMany(p => p.DrugItems)
            .WithOne(p => p.DrugStore)
            .HasForeignKey(p => p.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}