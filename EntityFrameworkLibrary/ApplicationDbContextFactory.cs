using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace EntityFrameworkLibrary;

internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    //private readonly IConfiguration _configuration;
    //public ApplicationDbContextFactory(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}

    public ApplicationDbContext CreateDbContext(string[]args)
    {
        // access the appsettings.json file in the RogoffMediaAPI:
        //string fileName = "appsettings.json";
        //string path = Path.Combine(Environment.CurrentDirectory, @"RogoffMediaApiApp\RogoffMediaApi\", fileName);

        //IConfiguration Configuration = new ConfigurationBuilder()
        //    .SetBasePath(Path.Combine(Environment.CurrentDirectory, @"RogoffMediaApiApp\RogoffMediaApi\"))
        //    .AddJsonFile("appsettings.json")
        //    .Build();


        DbContextOptionsBuilder<ApplicationDbContext> builder = new ();
        //builder.UseSqlServer(Configuration.GetConnectionString("RogoffMedia"));
        builder.UseSqlServer("Data Source = LCANB - OGNRTZ4ME\\SQLEXPRESS; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False",
            b => b.MigrationsAssembly("RogoffMediaApi"));

        return new ApplicationDbContext(builder.Options);
    }
}
