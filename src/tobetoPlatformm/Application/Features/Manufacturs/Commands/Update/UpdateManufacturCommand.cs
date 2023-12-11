using Application.Features.Manufacturs.Constants;
using Application.Features.Manufacturs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Manufacturs.Constants.ManufactursOperationClaims;

namespace Application.Features.Manufacturs.Commands.Update;

public class UpdateManufacturCommand : IRequest<UpdatedManufacturResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, ManufactursOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetManufacturs";

    public class UpdateManufacturCommandHandler : IRequestHandler<UpdateManufacturCommand, UpdatedManufacturResponse>
    {
        private readonly IMapper _mapper;
        private readonly IManufacturRepository _manufacturRepository;
        private readonly ManufacturBusinessRules _manufacturBusinessRules;

        public UpdateManufacturCommandHandler(IMapper mapper, IManufacturRepository manufacturRepository,
                                         ManufacturBusinessRules manufacturBusinessRules)
        {
            _mapper = mapper;
            _manufacturRepository = manufacturRepository;
            _manufacturBusinessRules = manufacturBusinessRules;
        }

        public async Task<UpdatedManufacturResponse> Handle(UpdateManufacturCommand request, CancellationToken cancellationToken)
        {
            Manufactur? manufactur = await _manufacturRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _manufacturBusinessRules.ManufacturShouldExistWhenSelected(manufactur);
            manufactur = _mapper.Map(request, manufactur);

            await _manufacturRepository.UpdateAsync(manufactur!);

            UpdatedManufacturResponse response = _mapper.Map<UpdatedManufacturResponse>(manufactur);
            return response;
        }
    }
}