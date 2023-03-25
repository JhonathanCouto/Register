using Microsoft.EntityFrameworkCore;
using Register.Domain;
using System.Reflection;

namespace Register.Infrastructure;

public sealed class Context : DbContext
{
    public Context(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
