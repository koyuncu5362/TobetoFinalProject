using FluentValidation;

namespace Application.Features.Manufacturs.Commands.Delete;

public class DeleteManufacturCommandValidator : AbstractValidator<DeleteManufacturCommand>
{
    public DeleteManufacturCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}