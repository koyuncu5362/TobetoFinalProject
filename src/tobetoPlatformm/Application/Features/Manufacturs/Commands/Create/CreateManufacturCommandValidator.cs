using FluentValidation;

namespace Application.Features.Manufacturs.Commands.Create;

public class CreateManufacturCommandValidator : AbstractValidator<CreateManufacturCommand>
{
    public CreateManufacturCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}