using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StreamVideoRepository : EfRepositoryBase<StreamVideo, Guid, BaseDbContext>, IStreamVideoRepository
{
    public StreamVideoRepository(BaseDbContext context) : base(context)
    {
    }
}