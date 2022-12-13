using Domain.Entities.Common;

namespace Domain.Entities.Main;

public class Country : Entity
{
    public string? Name { get; set; }
    public Region? Region { get; set; }
    public string? Code { get; set; }
}