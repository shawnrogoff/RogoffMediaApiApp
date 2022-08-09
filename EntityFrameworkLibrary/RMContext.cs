﻿using EntityFrameworkLibrary.TableConfigurations;
using Microsoft.EntityFrameworkCore;
using RogoffMediaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLibrary
{
    public class RMContext : DbContext
    {
        // To add migrations with our custom RMContext:
        // dotnet ef migrations add InitialCreate --context RMContext


        public RMContext(DbContextOptions<RMContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}
