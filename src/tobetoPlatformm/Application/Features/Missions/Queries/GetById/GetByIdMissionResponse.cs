using Core.Application.Responses;

namespace Application.Features.Missions.Queries.GetById;

public class GetByIdMissionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Header { get; set; }
    public DateTime Duration { get; set; }
    public string Description { get; set; }
    public string? VideoUrl { get; set; }
}