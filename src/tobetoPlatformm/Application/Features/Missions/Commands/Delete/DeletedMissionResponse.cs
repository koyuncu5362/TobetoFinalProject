using Core.Application.Responses;

namespace Application.Features.Missions.Commands.Delete;

public class DeletedMissionResponse : IResponse
{
    public Guid Id { get; set; }
}