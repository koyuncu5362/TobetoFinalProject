using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IManufacturRepository : IAsyncRepository<Manufactur, Guid>, IRepository<Manufactur, Guid>
{
}