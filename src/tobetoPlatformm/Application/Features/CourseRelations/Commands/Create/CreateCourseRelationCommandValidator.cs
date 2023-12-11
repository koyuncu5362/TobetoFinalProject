using FluentValidation;

namespace Application.Features.CourseRelations.Commands.Create;

public class CreateCourseRelationCommandValidator : AbstractValidator<CreateCourseRelationCommand>
{
    public CreateCourseRelationCommandValidator()
    {
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.CourseContentId).NotEmpty();
        RuleFor(c => c.MissionId).NotEmpty();
        RuleFor(c => c.StreamVideoId).NotEmpty();
        RuleFor(c => c.VideoId).NotEmpty();
    }
}