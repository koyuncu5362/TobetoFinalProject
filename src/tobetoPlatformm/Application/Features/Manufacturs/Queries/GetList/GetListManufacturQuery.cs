using Application.Features.Manufacturs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Manufacturs.Constants.ManufactursOperationClaims;

namespace Application.Features.Manufacturs.Queries.GetList;

public class GetListManufacturQuery : IRequest<GetListResponse<GetListManufacturListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListManufacturs({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetManufacturs";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListManufacturQueryHandler : IRequestHandler<GetListManufacturQuery, GetListResponse<GetListManufacturListItemDto>>
    {
        private readonly IManufacturRepository _manufacturRepository;
        private readonly IMapper _mapper;

        public GetListManufacturQueryHandler(IManufacturRepository manufacturRepository, IMapper mapper)
        {
            _manufacturRepository = manufacturRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListManufacturListItemDto>> Handle(GetListManufacturQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Manufactur> manufacturs = await _manufacturRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListManufacturListItemDto> response = _mapper.Map<GetListResponse<GetListManufacturListItemDto>>(manufacturs);
            return response;
        }
    }
}