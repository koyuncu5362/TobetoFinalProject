using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ManufacturRepository : EfRepositoryBase<Manufactur, Guid, BaseDbContext>, IManufacturRepository
{
    public ManufacturRepository(BaseDbContext context) : base(context)
    {
    }
}