using Application.Features.Videos.Constants;
using Application.Features.Videos.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Videos.Constants.VideosOperationClaims;

namespace Application.Features.Videos.Commands.Create;

public class CreateVideoCommand : IRequest<CreatedVideoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public int? Like { get; set; }
    public int? Views { get; set; }
    public DateTime Duration { get; set; }
    public Category Category { get; set; }
    public Manufactur Manufactur { get; set; }

    public string[] Roles => new[] { Admin, Write, VideosOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetVideos";

    public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand, CreatedVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepository;
        private readonly VideoBusinessRules _videoBusinessRules;

        public CreateVideoCommandHandler(IMapper mapper, IVideoRepository videoRepository,
                                         VideoBusinessRules videoBusinessRules)
        {
            _mapper = mapper;
            _videoRepository = videoRepository;
            _videoBusinessRules = videoBusinessRules;
        }

        public async Task<CreatedVideoResponse> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            Video video = _mapper.Map<Video>(request);

            await _videoRepository.AddAsync(video);

            CreatedVideoResponse response = _mapper.Map<CreatedVideoResponse>(video);
            return response;
        }
    }
}