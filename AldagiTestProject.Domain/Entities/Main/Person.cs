// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

using Domain.Entities.Common;

namespace Domain.Entities.Main;

public class Person : Entity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public GenderEnum Gender { get; set; }
    public string? IdNumber { get; set; }
    public Country? Citizenship { get; set; }
    public string? Email { get; set; }

    public int Age => GetAge();

    public int GetAge()
    {
        var dateTimeToday = DateTime.Today;
        var difference = dateTimeToday.Year - DateOfBirth.Year;
        return dateTimeToday.Date.Month > DateOfBirth.Month ? difference : difference - 1;
    }
    
    public enum GenderEnum
    {
        Female,
        Male,
        Other
    }
}