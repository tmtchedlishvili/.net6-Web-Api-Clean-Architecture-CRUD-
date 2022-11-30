using Application.Common.Interfaces;
using Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB;

public class ApplicationDBContext : DbContext, IApplicationDBContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    public DbSet<AppSetting> AppSettings { get; set; }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}