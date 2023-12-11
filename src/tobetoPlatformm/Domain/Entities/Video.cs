using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Video : Entity<Guid>
{
    public string Name { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public int? Like { get; set; }
    public int? Views { get; set; }
    public DateTime Duration { get; set; }
    public virtual Category  CategoryNavigation { get; set; }
    public virtual Manufactur ManufacturNavigation { get; set; }//Üretici Firma
}
