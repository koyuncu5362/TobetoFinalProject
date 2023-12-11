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

namespace Application.Features.Videos.Commands.Update;

public class UpdateVideoCommand : IRequest<UpdatedVideoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public int? Like { get; set; }
    public int? Views { get; set; }
    public DateTime Duration { get; set; }
    public Category Category { get; set; }
    public Manufactur Manufactur { get; set; }

    public string[] Roles => new[] { Admin, Write, VideosOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetVideos";

    public class UpdateVideoCommandHandler : IRequestHandler<UpdateVideoCommand, UpdatedVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepository;
        private readonly VideoBusinessRules _videoBusinessRules;

        public UpdateVideoCommandHandler(IMapper mapper, IVideoRepository videoRepository,
                                         VideoBusinessRules videoBusinessRules)
        {
            _mapper = mapper;
            _videoRepository = videoRepository;
            _videoBusinessRules = videoBusinessRules;
        }

        public async Task<UpdatedVideoResponse> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
        {
            Video? video = await _videoRepository.GetAsync(predicate: v => v.Id == request.Id, cancellationToken: cancellationToken);
            await _videoBusinessRules.VideoShouldExistWhenSelected(video);
            video = _mapper.Map(request, video);

            await _videoRepository.UpdateAsync(video!);

            UpdatedVideoResponse response = _mapper.Map<UpdatedVideoResponse>(video);
            return response;
        }
    }
}