using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Manufacturs;

public interface IManufactursService
{
    Task<Manufactur?> GetAsync(
        Expression<Func<Manufactur, bool>> predicate,
        Func<IQueryable<Manufactur>, IIncludableQueryable<Manufactur, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Manufactur>?> GetListAsync(
        Expression<Func<Manufactur, bool>>? predicate = null,
        Func<IQueryable<Manufactur>, IOrderedQueryable<Manufactur>>? orderBy = null,
        Func<IQueryable<Manufactur>, IIncludableQueryable<Manufactur, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Manufactur> AddAsync(Manufactur manufactur);
    Task<Manufactur> UpdateAsync(Manufactur manufactur);
    Task<Manufactur> DeleteAsync(Manufactur manufactur, bool permanent = false);
}
