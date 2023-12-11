using FluentValidation;

namespace Application.Features.Videos.Commands.Update;

public class UpdateVideoCommandValidator : AbstractValidator<UpdateVideoCommand>
{
    public UpdateVideoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Language).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.SubType).NotEmpty();
        RuleFor(c => c.Like).NotEmpty();
        RuleFor(c => c.Views).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.Category).NotEmpty();
        RuleFor(c => c.Manufactur).NotEmpty();
    }
}