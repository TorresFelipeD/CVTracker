using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Database.Models;

namespace Database.Context
{
    public class CVTrackerContext: DbContext
    {
        public CVTrackerContext(DbContextOptions<CVTrackerContext> options) : base(options)
        {
        }

        public DbSet<Company>? Companies { get; set; }
    }
}