using FluentValidation;

namespace Application.Features.CourseRelations.Commands.Update;

public class UpdateCourseRelationCommandValidator : AbstractValidator<UpdateCourseRelationCommand>
{
    public UpdateCourseRelationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.CourseContentId).NotEmpty();
        RuleFor(c => c.MissionId).NotEmpty();
        RuleFor(c => c.StreamVideoId).NotEmpty();
        RuleFor(c => c.VideoId).NotEmpty();
    }
}