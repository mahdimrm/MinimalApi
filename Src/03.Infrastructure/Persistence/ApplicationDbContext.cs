using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class ApplicationDbContext : DbContext
{
    public static string ConnectionString { get; set; } = null!;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(ConnectionString);

    }

    public DbSet<TodoItem> TodoItems { get; set; }
}
