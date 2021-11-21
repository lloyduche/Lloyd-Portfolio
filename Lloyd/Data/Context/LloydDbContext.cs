using Lloyd.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloyd.Data.Context
{
    public class LloydDbContext: IdentityDbContext<AppUser>
    {


        public LloydDbContext(DbContextOptions<LloydDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
