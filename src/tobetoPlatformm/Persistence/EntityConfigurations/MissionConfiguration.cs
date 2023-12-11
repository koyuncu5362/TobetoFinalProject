using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MissionConfiguration : IEntityTypeConfiguration<Mission>
{
    public void Configure(EntityTypeBuilder<Mission> builder)
    {
        builder.ToTable("Missions").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.Header).HasColumnName("Header");
        builder.Property(m => m.Duration).HasColumnName("Duration");
        builder.Property(m => m.Description).HasColumnName("Description");
        builder.Property(m => m.VideoUrl).HasColumnName("VideoUrl");
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");
        builder.HasIndex(indexExpression: b => b.Header, name: "UK_Missions_Name").IsUnique();
      
        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}