using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseContentConfiguration : IEntityTypeConfiguration<CourseContent>
{
    public void Configure(EntityTypeBuilder<CourseContent> builder)
    {
        builder.ToTable("CourseContents").HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id).HasColumnName("Id").IsRequired();
        builder.Property(cc => cc.Header).HasColumnName("Header");
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate");
        builder.HasIndex(indexExpression: b => b.Header, name: "UK_CourseContents_Name").IsUnique();
        builder.HasMany(b => b.Videos);
        builder.HasMany(b => b.Missions);
        builder.HasMany(b => b.StreamVideos);
        builder.HasQueryFilter(cc => !cc.DeletedDate.HasValue);
    }
}