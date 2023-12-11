using Core.Application.Responses;

namespace Application.Features.Manufacturs.Commands.Update;

public class UpdatedManufacturResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}