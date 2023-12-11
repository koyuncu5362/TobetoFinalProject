using FluentValidation;

namespace Application.Features.CourseRelations.Commands.Delete;

public class DeleteCourseRelationCommandValidator : AbstractValidator<DeleteCourseRelationCommand>
{
    public DeleteCourseRelationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}