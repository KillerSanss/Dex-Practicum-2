using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация DrugItem для базы данных
/// </summary>
public class DrugItemConfiguration : IEntityTypeConfiguration<DrugItem>
{
    /// <summary>
    /// Метод конфигурации
    /// </summary>
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        builder.ToTable(nameof(DrugItem), tableBuilder =>
        {
            tableBuilder.HasCheckConstraint("CK_Price_GreaterThanOrEqualZero", "[price] >= 0");
            tableBuilder.HasCheckConstraint("CK_Amount_Range", "[amount] >= 0 AND [amount] <= 10000");
        });
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<BaseEntity>(nameof(BaseEntity.Id)));

        builder.Property(p => p.DrugId)
            .IsRequired()
            .HasColumnName("drug_id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<DrugItem>(nameof(DrugItem.DrugId)));

        builder.Property(p => p.DrugStoreId)
            .IsRequired()
            .HasColumnName("drugstore_id")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<DrugItem>(nameof(DrugItem.DrugStore)));

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnName("price")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<DrugItem>(nameof(DrugItem.Price)));
        
        builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnName("amount")
            .HasAnnotation("Comment", GetPropertyAnnotation.GetPropertyComment<DrugItem>(nameof(DrugItem.Amount)));
        
        builder.HasOne(p => p.Drug)
            .WithMany()
            .HasForeignKey(p => p.DrugId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.DrugStore)
            .WithMany()
            .HasForeignKey(p => p.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}