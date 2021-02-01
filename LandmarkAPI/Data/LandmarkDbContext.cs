using LandmarksAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LandmarkAPI.Data
{
    public class LandmarkDbContext : IdentityDbContext
    {
        public LandmarkDbContext(DbContextOptions<LandmarkDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Icon> Icons { get; set; }

    }
}