using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseRelationConfiguration : IEntityTypeConfiguration<CourseRelation>
{
    public void Configure(EntityTypeBuilder<CourseRelation> builder)
    {
        builder.ToTable("CourseRelations").HasKey(cr => cr.Id);

        builder.Property(cr => cr.Id).HasColumnName("Id").IsRequired();
        builder.Property(cr => cr.CategoryId).HasColumnName("CategoryId");
        builder.Property(cr => cr.CourseId).HasColumnName("CourseId");
        builder.Property(cr => cr.CourseContentId).HasColumnName("CourseContentId");
        builder.Property(cr => cr.MissionId).HasColumnName("MissionId");
        builder.Property(cr => cr.StreamVideoId).HasColumnName("StreamVideoId");
        builder.Property(cr => cr.VideoId).HasColumnName("VideoId");
        builder.Property(cr => cr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cr => cr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cr => cr.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cr => !cr.DeletedDate.HasValue);
    }
}