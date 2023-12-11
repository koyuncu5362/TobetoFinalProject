using Application.Features.StreamVideos.Constants;
using Application.Features.StreamVideos.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.StreamVideos.Constants.StreamVideosOperationClaims;

namespace Application.Features.StreamVideos.Commands.Create;

public class CreateStreamVideoCommand : IRequest<CreatedStreamVideoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public string? RecordVideo { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public string[] Roles => new[] { Admin, Write, StreamVideosOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStreamVideos";

    public class CreateStreamVideoCommandHandler : IRequestHandler<CreateStreamVideoCommand, CreatedStreamVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStreamVideoRepository _streamVideoRepository;
        private readonly StreamVideoBusinessRules _streamVideoBusinessRules;

        public CreateStreamVideoCommandHandler(IMapper mapper, IStreamVideoRepository streamVideoRepository,
                                         StreamVideoBusinessRules streamVideoBusinessRules)
        {
            _mapper = mapper;
            _streamVideoRepository = streamVideoRepository;
            _streamVideoBusinessRules = streamVideoBusinessRules;
        }

        public async Task<CreatedStreamVideoResponse> Handle(CreateStreamVideoCommand request, CancellationToken cancellationToken)
        {
            StreamVideo streamVideo = _mapper.Map<StreamVideo>(request);

            await _streamVideoRepository.AddAsync(streamVideo);

            CreatedStreamVideoResponse response = _mapper.Map<CreatedStreamVideoResponse>(streamVideo);
            return response;
        }
    }
}