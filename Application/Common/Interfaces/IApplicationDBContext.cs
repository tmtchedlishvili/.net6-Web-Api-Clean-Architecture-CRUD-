using Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;
// ReSharper disable InconsistentNaming

namespace Application.Common.Interfaces;

public interface IApplicationDBContext
{
    DbSet<AppSetting> AppSettings { get; set; }
    Task<int> SaveChangesAsync();
}