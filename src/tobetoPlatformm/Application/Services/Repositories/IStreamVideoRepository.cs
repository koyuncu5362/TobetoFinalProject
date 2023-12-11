using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStreamVideoRepository : IAsyncRepository<StreamVideo, Guid>, IRepository<StreamVideo, Guid>
{
}