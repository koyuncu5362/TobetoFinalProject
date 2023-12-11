using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseRelations;

public interface ICourseRelationsService
{
    Task<CourseRelation?> GetAsync(
        Expression<Func<CourseRelation, bool>> predicate,
        Func<IQueryable<CourseRelation>, IIncludableQueryable<CourseRelation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CourseRelation>?> GetListAsync(
        Expression<Func<CourseRelation, bool>>? predicate = null,
        Func<IQueryable<CourseRelation>, IOrderedQueryable<CourseRelation>>? orderBy = null,
        Func<IQueryable<CourseRelation>, IIncludableQueryable<CourseRelation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CourseRelation> AddAsync(CourseRelation courseRelation);
    Task<CourseRelation> UpdateAsync(CourseRelation courseRelation);
    Task<CourseRelation> DeleteAsync(CourseRelation courseRelation, bool permanent = false);
}
