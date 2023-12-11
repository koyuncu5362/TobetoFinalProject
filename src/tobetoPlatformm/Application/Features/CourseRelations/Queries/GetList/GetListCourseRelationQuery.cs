using Application.Features.CourseRelations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CourseRelations.Constants.CourseRelationsOperationClaims;

namespace Application.Features.CourseRelations.Queries.GetList;

public class GetListCourseRelationQuery : IRequest<GetListResponse<GetListCourseRelationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCourseRelations({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCourseRelations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCourseRelationQueryHandler : IRequestHandler<GetListCourseRelationQuery, GetListResponse<GetListCourseRelationListItemDto>>
    {
        private readonly ICourseRelationRepository _courseRelationRepository;
        private readonly IMapper _mapper;

        public GetListCourseRelationQueryHandler(ICourseRelationRepository courseRelationRepository, IMapper mapper)
        {
            _courseRelationRepository = courseRelationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseRelationListItemDto>> Handle(GetListCourseRelationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseRelation> courseRelations = await _courseRelationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseRelationListItemDto> response = _mapper.Map<GetListResponse<GetListCourseRelationListItemDto>>(courseRelations);
            return response;
        }
    }
}