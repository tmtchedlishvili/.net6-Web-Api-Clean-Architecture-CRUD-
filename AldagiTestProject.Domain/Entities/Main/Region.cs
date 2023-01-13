using Domain.Entities.Common;

namespace Domain.Entities.Main;

public class Region : Entity
{
    public Region()
    {
        
    }
    public Region(string? name)
    {
        Name = name;
    }

    public string? Name { get; private set; }
}