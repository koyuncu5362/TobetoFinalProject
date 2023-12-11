using Core.Application.Responses;

namespace Application.Features.CourseRelations.Commands.Delete;

public class DeletedCourseRelationResponse : IResponse
{
    public Guid Id { get; set; }
}