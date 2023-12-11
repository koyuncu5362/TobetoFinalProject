using Application.Features.Missions.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Missions;

public class MissionsManager : IMissionsService
{
    private readonly IMissionRepository _missionRepository;
    private readonly MissionBusinessRules _missionBusinessRules;

    public MissionsManager(IMissionRepository missionRepository, MissionBusinessRules missionBusinessRules)
    {
        _missionRepository = missionRepository;
        _missionBusinessRules = missionBusinessRules;
    }

    public async Task<Mission?> GetAsync(
        Expression<Func<Mission, bool>> predicate,
        Func<IQueryable<Mission>, IIncludableQueryable<Mission, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Mission? mission = await _missionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return mission;
    }

    public async Task<IPaginate<Mission>?> GetListAsync(
        Expression<Func<Mission, bool>>? predicate = null,
        Func<IQueryable<Mission>, IOrderedQueryable<Mission>>? orderBy = null,
        Func<IQueryable<Mission>, IIncludableQueryable<Mission, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Mission> missionList = await _missionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return missionList;
    }

    public async Task<Mission> AddAsync(Mission mission)
    {
        Mission addedMission = await _missionRepository.AddAsync(mission);

        return addedMission;
    }

    public async Task<Mission> UpdateAsync(Mission mission)
    {
        Mission updatedMission = await _missionRepository.UpdateAsync(mission);

        return updatedMission;
    }

    public async Task<Mission> DeleteAsync(Mission mission, bool permanent = false)
    {
        Mission deletedMission = await _missionRepository.DeleteAsync(mission);

        return deletedMission;
    }
}
