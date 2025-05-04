using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Library.Infrastructure.Persistence;

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        string dbPath = DatabaseConfig.GetDatabasePath();
        optionsBuilder.UseSqlite($"Data Source=library.db");
        return new DatabaseContext(optionsBuilder.Options);
    }
}