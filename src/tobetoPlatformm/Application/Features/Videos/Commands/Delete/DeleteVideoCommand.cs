using Application.Features.Videos.Constants;
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

namespace Application.Features.Videos.Commands.Delete;

public class DeleteVideoCommand : IRequest<DeletedVideoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, VideosOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetVideos";

    public class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommand, DeletedVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepository;
        private readonly VideoBusinessRules _videoBusinessRules;

        public DeleteVideoCommandHandler(IMapper mapper, IVideoRepository videoRepository,
                                         VideoBusinessRules videoBusinessRules)
        {
            _mapper = mapper;
            _videoRepository = videoRepository;
            _videoBusinessRules = videoBusinessRules;
        }

        public async Task<DeletedVideoResponse> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
        {
            Video? video = await _videoRepository.GetAsync(predicate: v => v.Id == request.Id, cancellationToken: cancellationToken);
            await _videoBusinessRules.VideoShouldExistWhenSelected(video);

            await _videoRepository.DeleteAsync(video!);

            DeletedVideoResponse response = _mapper.Map<DeletedVideoResponse>(video);
            return response;
        }
    }
}