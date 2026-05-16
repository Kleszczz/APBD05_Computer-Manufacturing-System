using APBD05_Computer_Manufacturing_System.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD05_Computer_Manufacturing_System.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext()
    {
        
    }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<PC> PCs { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}