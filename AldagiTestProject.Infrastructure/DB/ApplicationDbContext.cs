using Application.Common.Interfaces;
using Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB;

public class ApplicationDbContext : DbContext, IApplicationDBContext
{
 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public ApplicationDbContext()
    {
    }

    public DbSet<AppSetting> AppSettings { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }


    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}