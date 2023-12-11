using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StreamVideos;

public interface IStreamVideosService
{
    Task<StreamVideo?> GetAsync(
        Expression<Func<StreamVideo, bool>> predicate,
        Func<IQueryable<StreamVideo>, IIncludableQueryable<StreamVideo, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StreamVideo>?> GetListAsync(
        Expression<Func<StreamVideo, bool>>? predicate = null,
        Func<IQueryable<StreamVideo>, IOrderedQueryable<StreamVideo>>? orderBy = null,
        Func<IQueryable<StreamVideo>, IIncludableQueryable<StreamVideo, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StreamVideo> AddAsync(StreamVideo streamVideo);
    Task<StreamVideo> UpdateAsync(StreamVideo streamVideo);
    Task<StreamVideo> DeleteAsync(StreamVideo streamVideo, bool permanent = false);
}
