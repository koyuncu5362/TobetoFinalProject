using Core.Application.Dtos;

namespace Application.Features.CourseRelations.Queries.GetList;

public class GetListCourseRelationListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid CourseId { get; set; }
    public Guid CourseContentId { get; set; }
    public Guid MissionId { get; set; }
    public Guid StreamVideoId { get; set; }
    public Guid VideoId { get; set; }
}