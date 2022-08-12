using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace EntityFrameworkLibrary;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContextFactory()
    {

    }

    private readonly IConfiguration _configuration;
    public ApplicationDbContextFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ApplicationDbContext CreateDbContext(string[]args)
    {
        // access the appsettings.json file in the RogoffMediaAPI:
        //string fileName = "appsettings.json";
        //string path = Path.Combine(Environment.CurrentDirectory, @"RogoffMediaApiApp\RogoffMediaApi\", fileName);
        
        //IConfiguration Configuration = new ConfigurationBuilder()
        //    .SetBasePath(Path.Combine(Environment.CurrentDirectory, @"RogoffMediaApiApp\RogoffMediaApi\"))
        //    .AddJsonFile("appsettings.json")
        //    .Build();


        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //builder.UseSqlServer(Configuration.GetConnectionString("RogoffMedia"));
        builder.UseSqlServer("Data Source = LCANB - OGNRTZ4ME\\SQLEXPRESS; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

        return new ApplicationDbContext(builder.Options);
    }
}
