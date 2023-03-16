using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using service.Models;

namespace service.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        try
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (databaseCreator != null)
            {
                if (!databaseCreator.CanConnect()) databaseCreator.Create();
                if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public DbSet<Product> Product { get; set; }
}