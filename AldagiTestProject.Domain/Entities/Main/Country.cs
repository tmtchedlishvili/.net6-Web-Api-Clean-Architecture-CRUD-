using Domain.Entities.Common;

namespace Domain.Entities.Main;

public class Country : Entity
{
    public Country()
    {
        
    }
    public Country(string? code, Region? region, string? name)
    {
        Code = code;
        Region = region;
        Name = name;
    }

    public string? Name { get; private set; }
    public Region? Region { get; private set; }
    public string? Code { get; private set; }
}