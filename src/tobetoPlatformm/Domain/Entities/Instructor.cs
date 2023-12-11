using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Instructor : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
}
