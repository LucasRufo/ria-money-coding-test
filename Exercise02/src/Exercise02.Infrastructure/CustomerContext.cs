using Exercise02.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Exercise02.Infrastructure;

public class CustomerContext : DbContext
{
    public CustomerContext() { }

    public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql().UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Customer> Customers { get; set; }
}