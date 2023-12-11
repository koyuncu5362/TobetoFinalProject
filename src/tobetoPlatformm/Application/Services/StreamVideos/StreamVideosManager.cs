using Application.Features.StreamVideos.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StreamVideos;

public class StreamVideosManager : IStreamVideosService
{
    private readonly IStreamVideoRepository _streamVideoRepository;
    private readonly StreamVideoBusinessRules _streamVideoBusinessRules;

    public StreamVideosManager(IStreamVideoRepository streamVideoRepository, StreamVideoBusinessRules streamVideoBusinessRules)
    {
        _streamVideoRepository = streamVideoRepository;
        _streamVideoBusinessRules = streamVideoBusinessRules;
    }

    public async Task<StreamVideo?> GetAsync(
        Expression<Func<StreamVideo, bool>> predicate,
        Func<IQueryable<StreamVideo>, IIncludableQueryable<StreamVideo, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StreamVideo? streamVideo = await _streamVideoRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return streamVideo;
    }

    public async Task<IPaginate<StreamVideo>?> GetListAsync(
        Expression<Func<StreamVideo, bool>>? predicate = null,
        Func<IQueryable<StreamVideo>, IOrderedQueryable<StreamVideo>>? orderBy = null,
        Func<IQueryable<StreamVideo>, IIncludableQueryable<StreamVideo, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StreamVideo> streamVideoList = await _streamVideoRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return streamVideoList;
    }

    public async Task<StreamVideo> AddAsync(StreamVideo streamVideo)
    {
        StreamVideo addedStreamVideo = await _streamVideoRepository.AddAsync(streamVideo);

        return addedStreamVideo;
    }

    public async Task<StreamVideo> UpdateAsync(StreamVideo streamVideo)
    {
        StreamVideo updatedStreamVideo = await _streamVideoRepository.UpdateAsync(streamVideo);

        return updatedStreamVideo;
    }

    public async Task<StreamVideo> DeleteAsync(StreamVideo streamVideo, bool permanent = false)
    {
        StreamVideo deletedStreamVideo = await _streamVideoRepository.DeleteAsync(streamVideo);

        return deletedStreamVideo;
    }
}
