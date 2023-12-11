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

namespace Application.Features.Missions.Commands.Update;

public class UpdateMissionCommand : IRequest<UpdatedMissionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Header { get; set; }
    public DateTime Duration { get; set; }
    public string Description { get; set; }
    public string? VideoUrl { get; set; }

    public string[] Roles => new[] { Admin, Write, MissionsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMissions";

    public class UpdateMissionCommandHandler : IRequestHandler<UpdateMissionCommand, UpdatedMissionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMissionRepository _missionRepository;
        private readonly MissionBusinessRules _missionBusinessRules;

        public UpdateMissionCommandHandler(IMapper mapper, IMissionRepository missionRepository,
                                         MissionBusinessRules missionBusinessRules)
        {
            _mapper = mapper;
            _missionRepository = missionRepository;
            _missionBusinessRules = missionBusinessRules;
        }

        public async Task<UpdatedMissionResponse> Handle(UpdateMissionCommand request, CancellationToken cancellationToken)
        {
            Mission? mission = await _missionRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _missionBusinessRules.MissionShouldExistWhenSelected(mission);
            mission = _mapper.Map(request, mission);

            await _missionRepository.UpdateAsync(mission!);

            UpdatedMissionResponse response = _mapper.Map<UpdatedMissionResponse>(mission);
            return response;
        }
    }
}