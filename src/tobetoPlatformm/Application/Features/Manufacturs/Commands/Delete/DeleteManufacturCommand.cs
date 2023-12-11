using Application.Features.Manufacturs.Constants;
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

namespace Application.Features.Manufacturs.Commands.Delete;

public class DeleteManufacturCommand : IRequest<DeletedManufacturResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ManufactursOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetManufacturs";

    public class DeleteManufacturCommandHandler : IRequestHandler<DeleteManufacturCommand, DeletedManufacturResponse>
    {
        private readonly IMapper _mapper;
        private readonly IManufacturRepository _manufacturRepository;
        private readonly ManufacturBusinessRules _manufacturBusinessRules;

        public DeleteManufacturCommandHandler(IMapper mapper, IManufacturRepository manufacturRepository,
                                         ManufacturBusinessRules manufacturBusinessRules)
        {
            _mapper = mapper;
            _manufacturRepository = manufacturRepository;
            _manufacturBusinessRules = manufacturBusinessRules;
        }

        public async Task<DeletedManufacturResponse> Handle(DeleteManufacturCommand request, CancellationToken cancellationToken)
        {
            Manufactur? manufactur = await _manufacturRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _manufacturBusinessRules.ManufacturShouldExistWhenSelected(manufactur);

            await _manufacturRepository.DeleteAsync(manufactur!);

            DeletedManufacturResponse response = _mapper.Map<DeletedManufacturResponse>(manufactur);
            return response;
        }
    }
}