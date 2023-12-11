using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CourseContent : Entity<Guid>
{
    public string Header { get; set; }
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; }
    public virtual ICollection<Video>? Videos { get; set; }
    public virtual ICollection<Mission>? Missions { get; set; }
    public virtual ICollection<StreamVideo>? StreamVideos { get; set; }


}
