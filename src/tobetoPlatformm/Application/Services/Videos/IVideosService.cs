using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Videos;

public interface IVideosService
{
    Task<Video?> GetAsync(
        Expression<Func<Video, bool>> predicate,
        Func<IQueryable<Video>, IIncludableQueryable<Video, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Video>?> GetListAsync(
        Expression<Func<Video, bool>>? predicate = null,
        Func<IQueryable<Video>, IOrderedQueryable<Video>>? orderBy = null,
        Func<IQueryable<Video>, IIncludableQueryable<Video, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Video> AddAsync(Video video);
    Task<Video> UpdateAsync(Video video);
    Task<Video> DeleteAsync(Video video, bool permanent = false);
}
