using FluentValidation;

namespace Application.Features.Missions.Commands.Delete;

public class DeleteMissionCommandValidator : AbstractValidator<DeleteMissionCommand>
{
    public DeleteMissionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}