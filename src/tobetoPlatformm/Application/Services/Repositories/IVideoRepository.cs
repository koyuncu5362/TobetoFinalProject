using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IVideoRepository : IAsyncRepository<Video, Guid>, IRepository<Video, Guid>
{
}