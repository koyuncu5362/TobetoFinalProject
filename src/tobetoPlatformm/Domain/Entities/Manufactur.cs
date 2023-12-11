using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Manufactur : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Video> Videos { get; set; }
}
