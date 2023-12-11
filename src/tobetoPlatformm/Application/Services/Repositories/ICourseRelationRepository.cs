using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseRelationRepository : IAsyncRepository<CourseRelation, Guid>, IRepository<CourseRelation, Guid>
{
}