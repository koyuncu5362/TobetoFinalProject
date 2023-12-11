using Application.Features.StreamVideos.Constants;
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

namespace Application.Features.StreamVideos.Commands.Delete;

public class DeleteStreamVideoCommand : IRequest<DeletedStreamVideoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, StreamVideosOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStreamVideos";

    public class DeleteStreamVideoCommandHandler : IRequestHandler<DeleteStreamVideoCommand, DeletedStreamVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStreamVideoRepository _streamVideoRepository;
        private readonly StreamVideoBusinessRules _streamVideoBusinessRules;

        public DeleteStreamVideoCommandHandler(IMapper mapper, IStreamVideoRepository streamVideoRepository,
                                         StreamVideoBusinessRules streamVideoBusinessRules)
        {
            _mapper = mapper;
            _streamVideoRepository = streamVideoRepository;
            _streamVideoBusinessRules = streamVideoBusinessRules;
        }

        public async Task<DeletedStreamVideoResponse> Handle(DeleteStreamVideoCommand request, CancellationToken cancellationToken)
        {
            StreamVideo? streamVideo = await _streamVideoRepository.GetAsync(predicate: sv => sv.Id == request.Id, cancellationToken: cancellationToken);
            await _streamVideoBusinessRules.StreamVideoShouldExistWhenSelected(streamVideo);

            await _streamVideoRepository.DeleteAsync(streamVideo!);

            DeletedStreamVideoResponse response = _mapper.Map<DeletedStreamVideoResponse>(streamVideo);
            return response;
        }
    }
}