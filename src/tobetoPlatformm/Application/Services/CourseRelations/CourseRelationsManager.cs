using Application.Features.CourseRelations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseRelations;

public class CourseRelationsManager : ICourseRelationsService
{
    private readonly ICourseRelationRepository _courseRelationRepository;
    private readonly CourseRelationBusinessRules _courseRelationBusinessRules;

    public CourseRelationsManager(ICourseRelationRepository courseRelationRepository, CourseRelationBusinessRules courseRelationBusinessRules)
    {
        _courseRelationRepository = courseRelationRepository;
        _courseRelationBusinessRules = courseRelationBusinessRules;
    }

    public async Task<CourseRelation?> GetAsync(
        Expression<Func<CourseRelation, bool>> predicate,
        Func<IQueryable<CourseRelation>, IIncludableQueryable<CourseRelation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CourseRelation? courseRelation = await _courseRelationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return courseRelation;
    }

    public async Task<IPaginate<CourseRelation>?> GetListAsync(
        Expression<Func<CourseRelation, bool>>? predicate = null,
        Func<IQueryable<CourseRelation>, IOrderedQueryable<CourseRelation>>? orderBy = null,
        Func<IQueryable<CourseRelation>, IIncludableQueryable<CourseRelation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CourseRelation> courseRelationList = await _courseRelationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return courseRelationList;
    }

    public async Task<CourseRelation> AddAsync(CourseRelation courseRelation)
    {
        CourseRelation addedCourseRelation = await _courseRelationRepository.AddAsync(courseRelation);

        return addedCourseRelation;
    }

    public async Task<CourseRelation> UpdateAsync(CourseRelation courseRelation)
    {
        CourseRelation updatedCourseRelation = await _courseRelationRepository.UpdateAsync(courseRelation);

        return updatedCourseRelation;
    }

    public async Task<CourseRelation> DeleteAsync(CourseRelation courseRelation, bool permanent = false)
    {
        CourseRelation deletedCourseRelation = await _courseRelationRepository.DeleteAsync(courseRelation);

        return deletedCourseRelation;
    }
}
