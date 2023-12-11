using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.ToTable("Videos").HasKey(v => v.Id);

        builder.Property(v => v.Id).HasColumnName("Id").IsRequired();
        builder.Property(v => v.Name).HasColumnName("Name");
        builder.Property(v => v.Language).HasColumnName("Language");
        builder.Property(v => v.Description).HasColumnName("Description");
        builder.Property(v => v.SubType).HasColumnName("SubType");
        builder.Property(v => v.Like).HasColumnName("Like");
        builder.Property(v => v.Views).HasColumnName("Views");
        builder.Property(v => v.CategoryId).HasColumnName("CategoryId");
        builder.Property(v => v.ManufacturerId).HasColumnName("ManufacturerId");
        builder.Property(v => v.Duration).HasColumnName("Duration");
        builder.Property(v => v.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(v => v.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(v => v.DeletedDate).HasColumnName("DeletedDate");
        builder.HasOne(b => b.CategoryNavigation);
        builder.HasOne(b => b.ManufacturNavigation);
        builder.HasQueryFilter(v => !v.DeletedDate.HasValue);
    }
}