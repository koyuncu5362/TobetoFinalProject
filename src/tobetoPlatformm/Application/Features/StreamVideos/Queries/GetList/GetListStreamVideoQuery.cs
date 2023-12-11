using Application.Features.StreamVideos.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.StreamVideos.Constants.StreamVideosOperationClaims;

namespace Application.Features.StreamVideos.Queries.GetList;

public class GetListStreamVideoQuery : IRequest<GetListResponse<GetListStreamVideoListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListStreamVideos({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetStreamVideos";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListStreamVideoQueryHandler : IRequestHandler<GetListStreamVideoQuery, GetListResponse<GetListStreamVideoListItemDto>>
    {
        private readonly IStreamVideoRepository _streamVideoRepository;
        private readonly IMapper _mapper;

        public GetListStreamVideoQueryHandler(IStreamVideoRepository streamVideoRepository, IMapper mapper)
        {
            _streamVideoRepository = streamVideoRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStreamVideoListItemDto>> Handle(GetListStreamVideoQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StreamVideo> streamVideos = await _streamVideoRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStreamVideoListItemDto> response = _mapper.Map<GetListResponse<GetListStreamVideoListItemDto>>(streamVideos);
            return response;
        }
    }
}