using FluentValidation;

namespace Application.Features.Missions.Commands.Update;

public class UpdateMissionCommandValidator : AbstractValidator<UpdateMissionCommand>
{
    public UpdateMissionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Header).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.VideoUrl).NotEmpty();
    }
}