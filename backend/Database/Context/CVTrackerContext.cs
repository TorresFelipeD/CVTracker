using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Database.Models;
using Database.InMemory;

namespace Database.Context
{
    public class CVTrackerContext: DbContext
    {
        public CVTrackerContext(DbContextOptions<CVTrackerContext> options) : base(options)
        {
        }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<EmploymentExchange>? EmploymentExchanges { get; set; }
        public DbSet<Requirement>? Requirements { get; set; }
        public DbSet<Skill>? Skills { get; set; }
        public DbSet<Status>? Status { get; set; }
        public DbSet<Job>? Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            InMemoryMethods inMemoryMethods = InMemoryMethods.GetInstance();
            modelBuilder.Entity<Company>().HasData(inMemoryMethods.CreateCompanies());
            modelBuilder.Entity<EmploymentExchange>().HasData(inMemoryMethods.CreateEmploymentExchanges());
            modelBuilder.Entity<Requirement>().HasData(inMemoryMethods.CreateRequirement());
            modelBuilder.Entity<Skill>().HasData(inMemoryMethods.CreateSkills());
            modelBuilder.Entity<Status>().HasData(inMemoryMethods.CreateStatus());
        }
    }
}