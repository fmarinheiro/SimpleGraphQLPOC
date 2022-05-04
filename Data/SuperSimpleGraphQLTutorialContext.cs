#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperSimpleGraphQLTutorial.Models;

namespace SuperSimpleGraphQLTutorial.Data
{
    public class SuperSimpleGraphQLTutorialContext : DbContext
    {
        public SuperSimpleGraphQLTutorialContext (DbContextOptions<SuperSimpleGraphQLTutorialContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Project> Project { get; set; }

        public DbSet<TimeLog> TimeLog { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(new Project
            {
                CreatedBy = "Giorgi",
                Id = 1,
                Name = "Migrate to TLS 1.2"
            }, new Project
            {
                CreatedBy = "Giorgi",
                Id = 2,
                Name = "Move Blog to Hugo"
            });

            modelBuilder.Entity<TimeLog>().HasData(new TimeLog
            {
                Id = 1,
                From = new DateTime(2020, 7, 24, 12, 0, 0),
                To = new DateTime(2020, 7, 24, 14, 0, 0),
                ProjectId = 1,
                User = "Giorgi"
            }, new TimeLog
            {
                Id = 2,
                From = new DateTime(2020, 7, 24, 16, 0, 0),
                To = new DateTime(2020, 7, 24, 18, 0, 0),
                ProjectId = 1,
                User = "Giorgi"
            }, new TimeLog
            {
                Id = 3,
                From = new DateTime(2020, 7, 24, 20, 0, 0),
                To = new DateTime(2020, 7, 24, 22, 0, 0),
                ProjectId = 2,
                User = "Giorgi"
            });
        }
    }


}
