using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Missions;

public interface IMissionsService
{
    Task<Mission?> GetAsync(
        Expression<Func<Mission, bool>> predicate,
        Func<IQueryable<Mission>, IIncludableQueryable<Mission, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Mission>?> GetListAsync(
        Expression<Func<Mission, bool>>? predicate = null,
        Func<IQueryable<Mission>, IOrderedQueryable<Mission>>? orderBy = null,
        Func<IQueryable<Mission>, IIncludableQueryable<Mission, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Mission> AddAsync(Mission mission);
    Task<Mission> UpdateAsync(Mission mission);
    Task<Mission> DeleteAsync(Mission mission, bool permanent = false);
}
