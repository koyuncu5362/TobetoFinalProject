using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Courses.Commands.Create;

public class CreatedCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int? Like { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Manufactur Manufactur { get; set; }
}