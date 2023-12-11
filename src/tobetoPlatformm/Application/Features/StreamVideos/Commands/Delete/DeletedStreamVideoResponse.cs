using Core.Application.Responses;

namespace Application.Features.StreamVideos.Commands.Delete;

public class DeletedStreamVideoResponse : IResponse
{
    public Guid Id { get; set; }
}