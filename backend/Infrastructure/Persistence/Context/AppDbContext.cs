using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

/// <summary>
/// Initializes a new instance of the class <see cref="AppDbContext"/>.
/// </summary>
/// <param name="options">The database context options.</param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Breed> Breeds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
}
