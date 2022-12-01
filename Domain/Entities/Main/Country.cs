using Domain.Entities.Common;

namespace Domain.Entities.Main;

public class Country : BaseEntity<int>
{
    public string? Name { get; set; }
    public Region? Region { get; set; }
    
}