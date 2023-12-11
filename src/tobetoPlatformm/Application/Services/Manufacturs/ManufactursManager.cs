using Application.Features.Manufacturs.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Manufacturs;

public class ManufactursManager : IManufactursService
{
    private readonly IManufacturRepository _manufacturRepository;
    private readonly ManufacturBusinessRules _manufacturBusinessRules;

    public ManufactursManager(IManufacturRepository manufacturRepository, ManufacturBusinessRules manufacturBusinessRules)
    {
        _manufacturRepository = manufacturRepository;
        _manufacturBusinessRules = manufacturBusinessRules;
    }

    public async Task<Manufactur?> GetAsync(
        Expression<Func<Manufactur, bool>> predicate,
        Func<IQueryable<Manufactur>, IIncludableQueryable<Manufactur, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Manufactur? manufactur = await _manufacturRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return manufactur;
    }

    public async Task<IPaginate<Manufactur>?> GetListAsync(
        Expression<Func<Manufactur, bool>>? predicate = null,
        Func<IQueryable<Manufactur>, IOrderedQueryable<Manufactur>>? orderBy = null,
        Func<IQueryable<Manufactur>, IIncludableQueryable<Manufactur, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Manufactur> manufacturList = await _manufacturRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return manufacturList;
    }

    public async Task<Manufactur> AddAsync(Manufactur manufactur)
    {
        Manufactur addedManufactur = await _manufacturRepository.AddAsync(manufactur);

        return addedManufactur;
    }

    public async Task<Manufactur> UpdateAsync(Manufactur manufactur)
    {
        Manufactur updatedManufactur = await _manufacturRepository.UpdateAsync(manufactur);

        return updatedManufactur;
    }

    public async Task<Manufactur> DeleteAsync(Manufactur manufactur, bool permanent = false)
    {
        Manufactur deletedManufactur = await _manufacturRepository.DeleteAsync(manufactur);

        return deletedManufactur;
    }
}
