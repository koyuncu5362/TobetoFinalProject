using Core.Application.Responses;

namespace Application.Features.Videos.Commands.Delete;

public class DeletedVideoResponse : IResponse
{
    public Guid Id { get; set; }
}