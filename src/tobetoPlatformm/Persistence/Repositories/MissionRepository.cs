using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MissionRepository : EfRepositoryBase<Mission, Guid, BaseDbContext>, IMissionRepository
{
    public MissionRepository(BaseDbContext context) : base(context)
    {
    }
}