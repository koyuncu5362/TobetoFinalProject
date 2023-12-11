using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Categories
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Delete" });
        #endregion
        #region Courses
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Delete" });
        #endregion
        #region CourseContents
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Delete" });
        #endregion
        #region Instructors
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Delete" });
        #endregion
        #region Manufacturs
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturs.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturs.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturs.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturs.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturs.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturs.Delete" });
        #endregion
        #region Missions
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Delete" });
        #endregion
        #region StreamVideos
        seeds.Add(new OperationClaim { Id = ++id, Name = "StreamVideos.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StreamVideos.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StreamVideos.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StreamVideos.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StreamVideos.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StreamVideos.Delete" });
        #endregion
        #region Videos
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Delete" });
        #endregion
        return seeds;
    }
}
