using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DemoCQRS.Persistence;

public class DemoDbContextFactory
    : IDesignTimeDbContextFactory<DemoDbContext>
{
    public DemoDbContext CreateDbContext(string[] args)
    {
        var modelBuilder = new DbContextOptionsBuilder<DemoDbContext>();
        string connectionString = "Host=localhost;Port=5433;Database=db_CQRS;Username=postgres;Password=root;"; // args[0];
        modelBuilder.UseNpgsql(connectionString);

        return new DemoDbContext(modelBuilder.Options);
    }
}
