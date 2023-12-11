using Application.Features.Videos.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Videos.Rules;

public class VideoBusinessRules : BaseBusinessRules
{
    private readonly IVideoRepository _videoRepository;

    public VideoBusinessRules(IVideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public Task VideoShouldExistWhenSelected(Video? video)
    {
        if (video == null)
            throw new BusinessException(VideosBusinessMessages.VideoNotExists);
        return Task.CompletedTask;
    }

    public async Task VideoIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Video? video = await _videoRepository.GetAsync(
            predicate: v => v.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await VideoShouldExistWhenSelected(video);
    }
}