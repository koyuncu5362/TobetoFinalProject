using FluentValidation;

namespace Application.Features.Missions.Commands.Create;

public class CreateMissionCommandValidator : AbstractValidator<CreateMissionCommand>
{
    public CreateMissionCommandValidator()
    {
        RuleFor(c => c.Header).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.VideoUrl).NotEmpty();
    }
}