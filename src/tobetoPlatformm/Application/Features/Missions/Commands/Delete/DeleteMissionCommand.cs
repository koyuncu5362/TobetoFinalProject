using Application.Features.Missions.Constants;
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

namespace Application.Features.Missions.Commands.Delete;

public class DeleteMissionCommand : IRequest<DeletedMissionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, MissionsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMissions";

    public class DeleteMissionCommandHandler : IRequestHandler<DeleteMissionCommand, DeletedMissionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMissionRepository _missionRepository;
        private readonly MissionBusinessRules _missionBusinessRules;

        public DeleteMissionCommandHandler(IMapper mapper, IMissionRepository missionRepository,
                                         MissionBusinessRules missionBusinessRules)
        {
            _mapper = mapper;
            _missionRepository = missionRepository;
            _missionBusinessRules = missionBusinessRules;
        }

        public async Task<DeletedMissionResponse> Handle(DeleteMissionCommand request, CancellationToken cancellationToken)
        {
            Mission? mission = await _missionRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _missionBusinessRules.MissionShouldExistWhenSelected(mission);

            await _missionRepository.DeleteAsync(mission!);

            DeletedMissionResponse response = _mapper.Map<DeletedMissionResponse>(mission);
            return response;
        }
    }
}