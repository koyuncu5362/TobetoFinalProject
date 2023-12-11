using Core.Application.Responses;

namespace Application.Features.CourseContents.Commands.Create;

public class CreatedCourseContentResponse : IResponse
{
    public Guid Id { get; set; }
    public string Header { get; set; }
}