
using BinaryWorks.CleanArchitectureTemplate.Domain.Entities;
using BinaryWorks.CleanArchitectureTemplate.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BinaryWorks.CleanArchitectureTemplate.Infrastructure.EntityFramework;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.ConfigureSmartEnum();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        // Set UpdatedUtc on entities
        var entities = ChangeTracker.Entries()
            .Where(x => x is {Entity: EntityBase, State: EntityState.Added or EntityState.Modified});

        foreach (var entity in entities)
        {
            entity.Property(nameof(EntityBase.UpdatedUtc)).CurrentValue = DateTime.UtcNow;
        }
        
        // Filter domain events
        
        var result = await base.SaveChangesAsync(cancellationToken);

        // Public domain events
        
        return result;
    }
    
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
}