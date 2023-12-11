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

namespace Application.Features.CourseRelations.Commands.Create;

public class CreateCourseRelationCommand : IRequest<CreatedCourseRelationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid CategoryId { get; set; }
    public Guid CourseId { get; set; }
    public Guid CourseContentId { get; set; }
    public Guid MissionId { get; set; }
    public Guid StreamVideoId { get; set; }
    public Guid VideoId { get; set; }

    public string[] Roles => new[] { Admin, Write, CourseRelationsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourseRelations";

    public class CreateCourseRelationCommandHandler : IRequestHandler<CreateCourseRelationCommand, CreatedCourseRelationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRelationRepository _courseRelationRepository;
        private readonly CourseRelationBusinessRules _courseRelationBusinessRules;

        public CreateCourseRelationCommandHandler(IMapper mapper, ICourseRelationRepository courseRelationRepository,
                                         CourseRelationBusinessRules courseRelationBusinessRules)
        {
            _mapper = mapper;
            _courseRelationRepository = courseRelationRepository;
            _courseRelationBusinessRules = courseRelationBusinessRules;
        }

        public async Task<CreatedCourseRelationResponse> Handle(CreateCourseRelationCommand request, CancellationToken cancellationToken)
        {
            CourseRelation courseRelation = _mapper.Map<CourseRelation>(request);

            await _courseRelationRepository.AddAsync(courseRelation);

            CreatedCourseRelationResponse response = _mapper.Map<CreatedCourseRelationResponse>(courseRelation);
            return response;
        }
    }
}