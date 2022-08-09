using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace EntityFrameworkLibrary;

public class RMContextFactory : IDesignTimeDbContextFactory<RMContext>
{
    public RMContextFactory()
    {
    }

    private IConfiguration Configuration =>
        new ConfigurationBuilder()
        .SetBasePath(Directory
        .GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

    public RMContext CreateDbContext(string[]args)
    {
        var builder = new DbContextOptionsBuilder<RMContext>();
        builder.UseSqlServer(Configuration.GetConnectionString("Default"));

        return new RMContext(builder.Options);
    }
}
