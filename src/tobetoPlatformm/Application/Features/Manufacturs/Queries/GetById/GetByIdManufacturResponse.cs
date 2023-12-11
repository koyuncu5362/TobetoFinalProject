using Core.Application.Responses;

namespace Application.Features.Manufacturs.Queries.GetById;

public class GetByIdManufacturResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}