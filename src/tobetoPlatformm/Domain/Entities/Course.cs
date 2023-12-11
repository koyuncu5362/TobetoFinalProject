using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Course : Entity<Guid>
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public string ImageUrl { get; set; }
    public int? Like { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<CourseContent> CourseContents { get; set; }
}
