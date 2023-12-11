using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ManufacturConfiguration : IEntityTypeConfiguration<Manufactur>
{
    public void Configure(EntityTypeBuilder<Manufactur> builder)
    {
        builder.ToTable("Manufacturs").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.Name).HasColumnName("Name");
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");
        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Manufacturs_Name").IsUnique();
      
        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}