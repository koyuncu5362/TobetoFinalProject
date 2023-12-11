using Core.Persistence.Repositories;

namespace Domain.Entities;

public class StreamVideo : Entity<Guid>
{
    public string Name { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public string? RecordVideo { get; set; }
    //public Guid ContentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual ICollection<Instructor> Instructors { get; set; }
}
