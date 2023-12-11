using Application.Features.Missions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Missions.Rules;

public class MissionBusinessRules : BaseBusinessRules
{
    private readonly IMissionRepository _missionRepository;

    public MissionBusinessRules(IMissionRepository missionRepository)
    {
        _missionRepository = missionRepository;
    }

    public Task MissionShouldExistWhenSelected(Mission? mission)
    {
        if (mission == null)
            throw new BusinessException(MissionsBusinessMessages.MissionNotExists);
        return Task.CompletedTask;
    }

    public async Task MissionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Mission? mission = await _missionRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MissionShouldExistWhenSelected(mission);
    }
}