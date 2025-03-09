using DemoCQRS.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DemoCQRS.Persistence;

public class DemoDbContext
    : DbContext
{
    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        :base(options)
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<UserStatus>();
    }

    public virtual DbSet<User> Users { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("user_status",
            Enum.GetNames(typeof(UserStatus))
            .Select(value => value.ToLower()).ToArray());

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
