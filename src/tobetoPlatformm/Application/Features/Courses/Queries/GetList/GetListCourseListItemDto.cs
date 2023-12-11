using Core.Application.Dtos;
using Domain.Entities;
namespace Application.Features.Courses.Queries.GetList;

public class GetListCourseListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int? Like { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Manufactur Manufactur { get; set; }
}