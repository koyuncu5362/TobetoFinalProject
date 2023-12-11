using Application.Features.StreamVideos.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StreamVideos.Rules;

public class StreamVideoBusinessRules : BaseBusinessRules
{
    private readonly IStreamVideoRepository _streamVideoRepository;

    public StreamVideoBusinessRules(IStreamVideoRepository streamVideoRepository)
    {
        _streamVideoRepository = streamVideoRepository;
    }

    public Task StreamVideoShouldExistWhenSelected(StreamVideo? streamVideo)
    {
        if (streamVideo == null)
            throw new BusinessException(StreamVideosBusinessMessages.StreamVideoNotExists);
        return Task.CompletedTask;
    }

    public async Task StreamVideoIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StreamVideo? streamVideo = await _streamVideoRepository.GetAsync(
            predicate: sv => sv.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StreamVideoShouldExistWhenSelected(streamVideo);
    }
}