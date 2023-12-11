using Core.Application.Dtos;

namespace Application.Features.Manufacturs.Queries.GetList;

public class GetListManufacturListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}