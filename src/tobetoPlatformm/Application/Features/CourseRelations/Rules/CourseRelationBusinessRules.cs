using Application.Features.CourseRelations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CourseRelations.Rules;

public class CourseRelationBusinessRules : BaseBusinessRules
{
    private readonly ICourseRelationRepository _courseRelationRepository;

    public CourseRelationBusinessRules(ICourseRelationRepository courseRelationRepository)
    {
        _courseRelationRepository = courseRelationRepository;
    }

    public Task CourseRelationShouldExistWhenSelected(CourseRelation? courseRelation)
    {
        if (courseRelation == null)
            throw new BusinessException(CourseRelationsBusinessMessages.CourseRelationNotExists);
        return Task.CompletedTask;
    }

    public async Task CourseRelationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CourseRelation? courseRelation = await _courseRelationRepository.GetAsync(
            predicate: cr => cr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseRelationShouldExistWhenSelected(courseRelation);
    }
}