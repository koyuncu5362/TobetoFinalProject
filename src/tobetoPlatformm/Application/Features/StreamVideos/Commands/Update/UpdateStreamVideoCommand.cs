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

namespace Application.Features.StreamVideos.Commands.Update;

public class UpdateStreamVideoCommand : IRequest<UpdatedStreamVideoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public string? RecordVideo { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public string[] Roles => new[] { Admin, Write, StreamVideosOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStreamVideos";

    public class UpdateStreamVideoCommandHandler : IRequestHandler<UpdateStreamVideoCommand, UpdatedStreamVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStreamVideoRepository _streamVideoRepository;
        private readonly StreamVideoBusinessRules _streamVideoBusinessRules;

        public UpdateStreamVideoCommandHandler(IMapper mapper, IStreamVideoRepository streamVideoRepository,
                                         StreamVideoBusinessRules streamVideoBusinessRules)
        {
            _mapper = mapper;
            _streamVideoRepository = streamVideoRepository;
            _streamVideoBusinessRules = streamVideoBusinessRules;
        }

        public async Task<UpdatedStreamVideoResponse> Handle(UpdateStreamVideoCommand request, CancellationToken cancellationToken)
        {
            StreamVideo? streamVideo = await _streamVideoRepository.GetAsync(predicate: sv => sv.Id == request.Id, cancellationToken: cancellationToken);
            await _streamVideoBusinessRules.StreamVideoShouldExistWhenSelected(streamVideo);
            streamVideo = _mapper.Map(request, streamVideo);

            await _streamVideoRepository.UpdateAsync(streamVideo!);

            UpdatedStreamVideoResponse response = _mapper.Map<UpdatedStreamVideoResponse>(streamVideo);
            return response;
        }
    }
}