using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseRelationRepository : EfRepositoryBase<CourseRelation, Guid, BaseDbContext>, ICourseRelationRepository
{
    public CourseRelationRepository(BaseDbContext context) : base(context)
    {
    }
}