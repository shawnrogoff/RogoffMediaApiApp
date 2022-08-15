using EntityFrameworkLibrary.TableConfigurations;
using Microsoft.EntityFrameworkCore;
using RogoffMediaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLibrary
{
    public class ApplicationDbContext : DbContext
    {
        // dotnet ef migrations add InitialCreate --context ApplicationDbContext

        // dotnet ef database update --startup-project ../RogoffMediaApi/RogoffMediaApi.csproj --context ApplicationDbContext

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new PostConfiguration());
            //modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
