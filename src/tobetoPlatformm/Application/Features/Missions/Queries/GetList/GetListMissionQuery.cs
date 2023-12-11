using Application.Features.Missions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Missions.Constants.MissionsOperationClaims;

namespace Application.Features.Missions.Queries.GetList;

public class GetListMissionQuery : IRequest<GetListResponse<GetListMissionListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListMissions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetMissions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMissionQueryHandler : IRequestHandler<GetListMissionQuery, GetListResponse<GetListMissionListItemDto>>
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IMapper _mapper;

        public GetListMissionQueryHandler(IMissionRepository missionRepository, IMapper mapper)
        {
            _missionRepository = missionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMissionListItemDto>> Handle(GetListMissionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Mission> missions = await _missionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMissionListItemDto> response = _mapper.Map<GetListResponse<GetListMissionListItemDto>>(missions);
            return response;
        }
    }
}