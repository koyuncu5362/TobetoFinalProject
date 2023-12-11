using Core.Application.Responses;

namespace Application.Features.Missions.Commands.Create;

public class CreatedMissionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Header { get; set; }
    public DateTime Duration { get; set; }
    public string Description { get; set; }
    public string? VideoUrl { get; set; }
}