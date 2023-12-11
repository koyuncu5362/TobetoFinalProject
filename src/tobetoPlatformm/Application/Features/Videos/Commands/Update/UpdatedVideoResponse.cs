using Core.Application.Responses;
using Domain.Entities;
namespace Application.Features.Videos.Commands.Update;

public class UpdatedVideoResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public int? Like { get; set; }
    public int? Views { get; set; }
    public DateTime Duration { get; set; }
    public Category Category { get; set; }
    public Manufactur Manufactur { get; set; }
}