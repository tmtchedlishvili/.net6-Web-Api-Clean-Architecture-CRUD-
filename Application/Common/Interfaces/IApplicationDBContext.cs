using Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;
// ReSharper disable InconsistentNaming

namespace Application.Common.Interfaces;

public interface IApplicationDBContext
{
    DbSet<AppSetting> AppSettings { get; set; }
    DbSet<Person> Persons { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<Region> Regions { get; set; }
    Task<int> SaveChangesAsync();
}