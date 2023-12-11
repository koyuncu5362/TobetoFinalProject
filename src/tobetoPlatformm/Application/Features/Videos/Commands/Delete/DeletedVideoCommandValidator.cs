using FluentValidation;

namespace Application.Features.Videos.Commands.Delete;

public class DeleteVideoCommandValidator : AbstractValidator<DeleteVideoCommand>
{
    public DeleteVideoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}