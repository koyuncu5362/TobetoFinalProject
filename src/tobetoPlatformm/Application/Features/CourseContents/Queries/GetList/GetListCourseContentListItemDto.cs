using Core.Application.Dtos;

namespace Application.Features.CourseContents.Queries.GetList;

public class GetListCourseContentListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Header { get; set; }
}