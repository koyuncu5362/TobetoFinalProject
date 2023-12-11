using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class VideoRepository : EfRepositoryBase<Video, Guid, BaseDbContext>, IVideoRepository
{
    public VideoRepository(BaseDbContext context) : base(context)
    {
    }
}