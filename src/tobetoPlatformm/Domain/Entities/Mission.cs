using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Mission : Entity<Guid>
{
    public string Header { get; set; }
    public DateTime Duration { get; set; }
    public string Description { get; set; }
    public string? VideoUrl { get; set; }
    //public Guid ContentId { get; set; }

}
