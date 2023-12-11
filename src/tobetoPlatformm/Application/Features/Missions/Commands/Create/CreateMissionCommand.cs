using Application.Features.Missions.Constants;
using Application.Features.Missions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Missions.Constants.MissionsOperationClaims;

namespace Application.Features.Missions.Commands.Create;

public class CreateMissionCommand : IRequest<CreatedMissionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Header { get; set; }
    public DateTime Duration { get; set; }
    public string Description { get; set; }
    public string? VideoUrl { get; set; }

    public string[] Roles => new[] { Admin, Write, MissionsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMissions";

    public class CreateMissionCommandHandler : IRequestHandler<CreateMissionCommand, CreatedMissionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMissionRepository _missionRepository;
        private readonly MissionBusinessRules _missionBusinessRules;

        public CreateMissionCommandHandler(IMapper mapper, IMissionRepository missionRepository,
                                         MissionBusinessRules missionBusinessRules)
        {
            _mapper = mapper;
            _missionRepository = missionRepository;
            _missionBusinessRules = missionBusinessRules;
        }

        public async Task<CreatedMissionResponse> Handle(CreateMissionCommand request, CancellationToken cancellationToken)
        {
            Mission mission = _mapper.Map<Mission>(request);

            await _missionRepository.AddAsync(mission);

            CreatedMissionResponse response = _mapper.Map<CreatedMissionResponse>(mission);
            return response;
        }
    }
}