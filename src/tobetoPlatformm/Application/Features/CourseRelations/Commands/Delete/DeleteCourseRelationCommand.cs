using Application.Features.CourseRelations.Constants;
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

namespace Application.Features.CourseRelations.Commands.Delete;

public class DeleteCourseRelationCommand : IRequest<DeletedCourseRelationResponse>,ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CourseRelationsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourseRelations";

    public class DeleteCourseRelationCommandHandler : IRequestHandler<DeleteCourseRelationCommand, DeletedCourseRelationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRelationRepository _courseRelationRepository;
        private readonly CourseRelationBusinessRules _courseRelationBusinessRules;

        public DeleteCourseRelationCommandHandler(IMapper mapper, ICourseRelationRepository courseRelationRepository,
                                         CourseRelationBusinessRules courseRelationBusinessRules)
        {
            _mapper = mapper;
            _courseRelationRepository = courseRelationRepository;
            _courseRelationBusinessRules = courseRelationBusinessRules;
        }

        public async Task<DeletedCourseRelationResponse> Handle(DeleteCourseRelationCommand request, CancellationToken cancellationToken)
        {
            CourseRelation? courseRelation = await _courseRelationRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _courseRelationBusinessRules.CourseRelationShouldExistWhenSelected(courseRelation);

            await _courseRelationRepository.DeleteAsync(courseRelation!);

            DeletedCourseRelationResponse response = _mapper.Map<DeletedCourseRelationResponse>(courseRelation);
            return response;
        }
    }
}