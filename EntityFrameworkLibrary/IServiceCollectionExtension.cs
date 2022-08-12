using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLibrary;

public static class IServiceCollectionExtension
{
    public static IServiceCollection ConfigureService(this IServiceCollection service, IConfiguration Configuration)
    {
        // access the appsettings.json file in the RogoffMediaAPI:
        string fileName = "appsettings.json";
        string path = Path.Combine(Environment.CurrentDirectory, @"RogoffMediaApiApp\RogoffMediaApi\", fileName);

        Configuration = new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(path))
            .AddJsonFile(fileName)
            .Build();

        service.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("RogoffMedia")));

        return service;
    }
}
