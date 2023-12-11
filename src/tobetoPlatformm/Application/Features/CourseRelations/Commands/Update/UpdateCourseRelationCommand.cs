using Application.Features.CourseRelations.Constants;
using Application.Features.CourseRelations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CourseRelations.Constants.CourseRelationsOperationClaims;

namespace Application.Features.CourseRelations.Commands.Update;

public class UpdateCourseRelationCommand : IRequest<UpdatedCourseRelationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid CourseId { get; set; }
    public Guid CourseContentId { get; set; }
    public Guid MissionId { get; set; }
    public Guid StreamVideoId { get; set; }
    public Guid VideoId { get; set; }

    public string[] Roles => new[] { Admin, Write, CourseRelationsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourseRelations";

    public class UpdateCourseRelationCommandHandler : IRequestHandler<UpdateCourseRelationCommand, UpdatedCourseRelationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRelationRepository _courseRelationRepository;
        private readonly CourseRelationBusinessRules _courseRelationBusinessRules;

        public UpdateCourseRelationCommandHandler(IMapper mapper, ICourseRelationRepository courseRelationRepository,
                                         CourseRelationBusinessRules courseRelationBusinessRules)
        {
            _mapper = mapper;
            _courseRelationRepository = courseRelationRepository;
            _courseRelationBusinessRules = courseRelationBusinessRules;
        }

        public async Task<UpdatedCourseRelationResponse> Handle(UpdateCourseRelationCommand request, CancellationToken cancellationToken)
        {
            CourseRelation? courseRelation = await _courseRelationRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _courseRelationBusinessRules.CourseRelationShouldExistWhenSelected(courseRelation);
            courseRelation = _mapper.Map(request, courseRelation);

            await _courseRelationRepository.UpdateAsync(courseRelation!);

            UpdatedCourseRelationResponse response = _mapper.Map<UpdatedCourseRelationResponse>(courseRelation);
            return response;
        }
    }
}