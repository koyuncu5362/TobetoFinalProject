using Application.Features.Manufacturs.Constants;
using Application.Features.Manufacturs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Manufacturs.Constants.ManufactursOperationClaims;

namespace Application.Features.Manufacturs.Queries.GetById;

public class GetByIdManufacturQuery : IRequest<GetByIdManufacturResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdManufacturQueryHandler : IRequestHandler<GetByIdManufacturQuery, GetByIdManufacturResponse>
    {
        private readonly IMapper _mapper;
        private readonly IManufacturRepository _manufacturRepository;
        private readonly ManufacturBusinessRules _manufacturBusinessRules;

        public GetByIdManufacturQueryHandler(IMapper mapper, IManufacturRepository manufacturRepository, ManufacturBusinessRules manufacturBusinessRules)
        {
            _mapper = mapper;
            _manufacturRepository = manufacturRepository;
            _manufacturBusinessRules = manufacturBusinessRules;
        }

        public async Task<GetByIdManufacturResponse> Handle(GetByIdManufacturQuery request, CancellationToken cancellationToken)
        {
            Manufactur? manufactur = await _manufacturRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _manufacturBusinessRules.ManufacturShouldExistWhenSelected(manufactur);

            GetByIdManufacturResponse response = _mapper.Map<GetByIdManufacturResponse>(manufactur);
            return response;
        }
    }
}