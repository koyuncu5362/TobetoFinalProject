using Core.Application.Dtos;

namespace Application.Features.Missions.Queries.GetList;

public class GetListMissionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Header { get; set; }
    public DateTime Duration { get; set; }
    public string Description { get; set; }
    public string? VideoUrl { get; set; }
}