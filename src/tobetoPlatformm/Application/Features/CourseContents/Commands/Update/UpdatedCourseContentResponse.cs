using Core.Application.Responses;

namespace Application.Features.CourseContents.Commands.Update;

public class UpdatedCourseContentResponse : IResponse
{
    public Guid Id { get; set; }
    public string Header { get; set; }
}