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

namespace Application.Features.Manufacturs.Commands.Create;

public class CreateManufacturCommand : IRequest<CreatedManufacturResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, ManufactursOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetManufacturs";

    public class CreateManufacturCommandHandler : IRequestHandler<CreateManufacturCommand, CreatedManufacturResponse>
    {
        private readonly IMapper _mapper;
        private readonly IManufacturRepository _manufacturRepository;
        private readonly ManufacturBusinessRules _manufacturBusinessRules;

        public CreateManufacturCommandHandler(IMapper mapper, IManufacturRepository manufacturRepository,
                                         ManufacturBusinessRules manufacturBusinessRules)
        {
            _mapper = mapper;
            _manufacturRepository = manufacturRepository;
            _manufacturBusinessRules = manufacturBusinessRules;
        }

        public async Task<CreatedManufacturResponse> Handle(CreateManufacturCommand request, CancellationToken cancellationToken)
        {
            Manufactur manufactur = _mapper.Map<Manufactur>(request);

            await _manufacturRepository.AddAsync(manufactur);

            CreatedManufacturResponse response = _mapper.Map<CreatedManufacturResponse>(manufactur);
            return response;
        }
    }
}