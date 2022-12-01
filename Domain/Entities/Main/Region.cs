using Domain.Entities.Common;

namespace Domain.Entities.Main;

public class Region : BaseEntity<int>
{
    public string? Name { get; set; }
}