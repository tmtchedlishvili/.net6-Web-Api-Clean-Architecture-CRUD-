using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsEnabled { get; set; }

    [IgnoreDataMember]
    public string FullName => $"{FirstName} {LastName}";
}