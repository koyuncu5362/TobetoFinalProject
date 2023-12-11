using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name");
        builder.Property(c => c.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(c => c.Like).HasColumnName("Like");
        builder.Property(c => c.StartDate).HasColumnName("StartDate");
        builder.Property(c => c.EndDate).HasColumnName("EndDate");
        builder.Property(c => c.CategoryId).HasColumnName("CategoryId");
       
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");
        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Courses_Name").IsUnique();
        builder.HasMany(b => b.CourseContents);
        builder.HasOne(b => b.Category);
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}