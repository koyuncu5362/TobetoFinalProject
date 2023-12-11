using FluentValidation;

namespace Application.Features.StreamVideos.Commands.Update;

public class UpdateStreamVideoCommandValidator : AbstractValidator<UpdateStreamVideoCommand>
{
    public UpdateStreamVideoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Language).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.SubType).NotEmpty();
        RuleFor(c => c.RecordVideo).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
    }
}