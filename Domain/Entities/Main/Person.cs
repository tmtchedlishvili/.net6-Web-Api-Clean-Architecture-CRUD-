// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

using Domain.Entities.Common;

namespace Domain.Entities.Main;

public class Person : BaseEntity<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}