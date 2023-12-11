using Application.Features.StreamVideos.Constants;
using Application.Features.StreamVideos.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.StreamVideos.Constants.StreamVideosOperationClaims;

namespace Application.Features.StreamVideos.Queries.GetById;

public class GetByIdStreamVideoQuery : IRequest<GetByIdStreamVideoResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdStreamVideoQueryHandler : IRequestHandler<GetByIdStreamVideoQuery, GetByIdStreamVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStreamVideoRepository _streamVideoRepository;
        private readonly StreamVideoBusinessRules _streamVideoBusinessRules;

        public GetByIdStreamVideoQueryHandler(IMapper mapper, IStreamVideoRepository streamVideoRepository, StreamVideoBusinessRules streamVideoBusinessRules)
        {
            _mapper = mapper;
            _streamVideoRepository = streamVideoRepository;
            _streamVideoBusinessRules = streamVideoBusinessRules;
        }

        public async Task<GetByIdStreamVideoResponse> Handle(GetByIdStreamVideoQuery request, CancellationToken cancellationToken)
        {
            StreamVideo? streamVideo = await _streamVideoRepository.GetAsync(predicate: sv => sv.Id == request.Id, cancellationToken: cancellationToken);
            await _streamVideoBusinessRules.StreamVideoShouldExistWhenSelected(streamVideo);

            GetByIdStreamVideoResponse response = _mapper.Map<GetByIdStreamVideoResponse>(streamVideo);
            return response;
        }
    }
}