using FluentValidation;

namespace Application.Features.CourseContents.Commands.Update;

public class UpdateCourseContentCommandValidator : AbstractValidator<UpdateCourseContentCommand>
{
    public UpdateCourseContentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Header).NotEmpty();
    }
}