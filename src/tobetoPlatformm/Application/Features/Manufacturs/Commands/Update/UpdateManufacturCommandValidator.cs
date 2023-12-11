using FluentValidation;

namespace Application.Features.Manufacturs.Commands.Update;

public class UpdateManufacturCommandValidator : AbstractValidator<UpdateManufacturCommand>
{
    public UpdateManufacturCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}