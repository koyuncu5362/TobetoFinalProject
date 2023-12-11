using Core.Application.Responses;

namespace Application.Features.Manufacturs.Commands.Create;

public class CreatedManufacturResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}