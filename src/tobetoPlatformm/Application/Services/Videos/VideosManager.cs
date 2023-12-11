using Application.Features.Videos.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Videos;

public class VideosManager : IVideosService
{
    private readonly IVideoRepository _videoRepository;
    private readonly VideoBusinessRules _videoBusinessRules;

    public VideosManager(IVideoRepository videoRepository, VideoBusinessRules videoBusinessRules)
    {
        _videoRepository = videoRepository;
        _videoBusinessRules = videoBusinessRules;
    }

    public async Task<Video?> GetAsync(
        Expression<Func<Video, bool>> predicate,
        Func<IQueryable<Video>, IIncludableQueryable<Video, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Video? video = await _videoRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return video;
    }

    public async Task<IPaginate<Video>?> GetListAsync(
        Expression<Func<Video, bool>>? predicate = null,
        Func<IQueryable<Video>, IOrderedQueryable<Video>>? orderBy = null,
        Func<IQueryable<Video>, IIncludableQueryable<Video, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Video> videoList = await _videoRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return videoList;
    }

    public async Task<Video> AddAsync(Video video)
    {
        Video addedVideo = await _videoRepository.AddAsync(video);

        return addedVideo;
    }

    public async Task<Video> UpdateAsync(Video video)
    {
        Video updatedVideo = await _videoRepository.UpdateAsync(video);

        return updatedVideo;
    }

    public async Task<Video> DeleteAsync(Video video, bool permanent = false)
    {
        Video deletedVideo = await _videoRepository.DeleteAsync(video);

        return deletedVideo;
    }
}
