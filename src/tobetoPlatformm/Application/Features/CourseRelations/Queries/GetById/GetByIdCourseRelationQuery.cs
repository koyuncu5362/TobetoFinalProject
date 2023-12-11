using Application.Features.CourseRelations.Constants;
using Application.Features.CourseRelations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CourseRelations.Constants.CourseRelationsOperationClaims;

namespace Application.Features.CourseRelations.Queries.GetById;

public class GetByIdCourseRelationQuery : IRequest<GetByIdCourseRelationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCourseRelationQueryHandler : IRequestHandler<GetByIdCourseRelationQuery, GetByIdCourseRelationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRelationRepository _courseRelationRepository;
        private readonly CourseRelationBusinessRules _courseRelationBusinessRules;

        public GetByIdCourseRelationQueryHandler(IMapper mapper, ICourseRelationRepository courseRelationRepository, CourseRelationBusinessRules courseRelationBusinessRules)
        {
            _mapper = mapper;
            _courseRelationRepository = courseRelationRepository;
            _courseRelationBusinessRules = courseRelationBusinessRules;
        }

        public async Task<GetByIdCourseRelationResponse> Handle(GetByIdCourseRelationQuery request, CancellationToken cancellationToken)
        {
            CourseRelation? courseRelation = await _courseRelationRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _courseRelationBusinessRules.CourseRelationShouldExistWhenSelected(courseRelation);

            GetByIdCourseRelationResponse response = _mapper.Map<GetByIdCourseRelationResponse>(courseRelation);
            return response;
        }
    }
}