using Application.Features.Manufacturs.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Manufacturs.Rules;

public class ManufacturBusinessRules : BaseBusinessRules
{
    private readonly IManufacturRepository _manufacturRepository;

    public ManufacturBusinessRules(IManufacturRepository manufacturRepository)
    {
        _manufacturRepository = manufacturRepository;
    }

    public Task ManufacturShouldExistWhenSelected(Manufactur? manufactur)
    {
        if (manufactur == null)
            throw new BusinessException(ManufactursBusinessMessages.ManufacturNotExists);
        return Task.CompletedTask;
    }

    public async Task ManufacturIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Manufactur? manufactur = await _manufacturRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ManufacturShouldExistWhenSelected(manufactur);
    }
}