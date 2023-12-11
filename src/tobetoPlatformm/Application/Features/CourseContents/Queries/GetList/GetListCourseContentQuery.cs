using Application.Features.CourseContents.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CourseContents.Constants.CourseContentsOperationClaims;

namespace Application.Features.CourseContents.Queries.GetList;

public class GetListCourseContentQuery : IRequest<GetListResponse<GetListCourseContentListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCourseContents({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCourseContents";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCourseContentQueryHandler : IRequestHandler<GetListCourseContentQuery, GetListResponse<GetListCourseContentListItemDto>>
    {
        private readonly ICourseContentRepository _courseContentRepository;
        private readonly IMapper _mapper;

        public GetListCourseContentQueryHandler(ICourseContentRepository courseContentRepository, IMapper mapper)
        {
            _courseContentRepository = courseContentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseContentListItemDto>> Handle(GetListCourseContentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseContent> courseContents = await _courseContentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseContentListItemDto> response = _mapper.Map<GetListResponse<GetListCourseContentListItemDto>>(courseContents);
            return response;
        }
    }
}