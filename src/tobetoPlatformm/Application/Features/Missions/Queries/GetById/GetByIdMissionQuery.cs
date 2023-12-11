using Application.Features.Missions.Constants;
using Application.Features.Missions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Missions.Constants.MissionsOperationClaims;

namespace Application.Features.Missions.Queries.GetById;

public class GetByIdMissionQuery : IRequest<GetByIdMissionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdMissionQueryHandler : IRequestHandler<GetByIdMissionQuery, GetByIdMissionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMissionRepository _missionRepository;
        private readonly MissionBusinessRules _missionBusinessRules;

        public GetByIdMissionQueryHandler(IMapper mapper, IMissionRepository missionRepository, MissionBusinessRules missionBusinessRules)
        {
            _mapper = mapper;
            _missionRepository = missionRepository;
            _missionBusinessRules = missionBusinessRules;
        }

        public async Task<GetByIdMissionResponse> Handle(GetByIdMissionQuery request, CancellationToken cancellationToken)
        {
            Mission? mission = await _missionRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _missionBusinessRules.MissionShouldExistWhenSelected(mission);

            GetByIdMissionResponse response = _mapper.Map<GetByIdMissionResponse>(mission);
            return response;
        }
    }
}