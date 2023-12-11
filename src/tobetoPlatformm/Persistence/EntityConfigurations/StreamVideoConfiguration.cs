using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StreamVideoConfiguration : IEntityTypeConfiguration<StreamVideo>
{
    public void Configure(EntityTypeBuilder<StreamVideo> builder)
    {
        builder.ToTable("StreamVideos").HasKey(sv => sv.Id);

        builder.Property(sv => sv.Id).HasColumnName("Id").IsRequired();
        builder.Property(sv => sv.Name).HasColumnName("Name");
        builder.Property(sv => sv.Language).HasColumnName("Language");
        builder.Property(sv => sv.Description).HasColumnName("Description");
        builder.Property(sv => sv.SubType).HasColumnName("SubType");
        builder.Property(sv => sv.RecordVideo).HasColumnName("RecordVideo");
        builder.Property(sv => sv.StartDate).HasColumnName("StartDate");
        builder.Property(sv => sv.EndDate).HasColumnName("EndDate");
        builder.Property(sv => sv.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sv => sv.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sv => sv.DeletedDate).HasColumnName("DeletedDate");
        builder.HasIndex(indexExpression: b => b.Name, name: "UK_StreamVideos_Name").IsUnique();
        builder.HasMany(b => b.Instructors);
        builder.HasQueryFilter(sv => !sv.DeletedDate.HasValue);
    }
}