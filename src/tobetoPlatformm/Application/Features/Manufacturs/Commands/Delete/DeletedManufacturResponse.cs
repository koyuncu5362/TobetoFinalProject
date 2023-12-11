using Core.Application.Responses;

namespace Application.Features.Manufacturs.Commands.Delete;

public class DeletedManufacturResponse : IResponse
{
    public Guid Id { get; set; }
}