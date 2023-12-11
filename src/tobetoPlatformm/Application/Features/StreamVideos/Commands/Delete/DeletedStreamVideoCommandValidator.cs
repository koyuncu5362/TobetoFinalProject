using FluentValidation;

namespace Application.Features.StreamVideos.Commands.Delete;

public class DeleteStreamVideoCommandValidator : AbstractValidator<DeleteStreamVideoCommand>
{
    public DeleteStreamVideoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}