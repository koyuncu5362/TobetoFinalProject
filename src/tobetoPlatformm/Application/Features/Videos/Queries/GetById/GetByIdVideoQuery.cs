using Application.Features.Videos.Constants;
using Application.Features.Videos.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Videos.Constants.VideosOperationClaims;

namespace Application.Features.Videos.Queries.GetById;

public class GetByIdVideoQuery : IRequest<GetByIdVideoResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdVideoQueryHandler : IRequestHandler<GetByIdVideoQuery, GetByIdVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepository;
        private readonly VideoBusinessRules _videoBusinessRules;

        public GetByIdVideoQueryHandler(IMapper mapper, IVideoRepository videoRepository, VideoBusinessRules videoBusinessRules)
        {
            _mapper = mapper;
            _videoRepository = videoRepository;
            _videoBusinessRules = videoBusinessRules;
        }

        public async Task<GetByIdVideoResponse> Handle(GetByIdVideoQuery request, CancellationToken cancellationToken)
        {
            Video? video = await _videoRepository.GetAsync(predicate: v => v.Id == request.Id, cancellationToken: cancellationToken);
            await _videoBusinessRules.VideoShouldExistWhenSelected(video);

            GetByIdVideoResponse response = _mapper.Map<GetByIdVideoResponse>(video);
            return response;
        }
    }
}