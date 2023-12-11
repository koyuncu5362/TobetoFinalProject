using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMissionRepository : IAsyncRepository<Mission, Guid>, IRepository<Mission, Guid>
{
}