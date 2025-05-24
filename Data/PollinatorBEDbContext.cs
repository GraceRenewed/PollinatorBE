using Microsoft.EntityFrameworkCore;
using PollinatorBE.Models;

namespace PollinatorBE.Data
{
    public class PollinatorBEDbContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Pollinator> Pollinators { get; set; }

        public PollinatorBEDbContext(DbContextOptions<PollinatorBEDbContext> options) : base(options)
        {
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UserProfile
            modelBuilder.Entity<UserProfile>()
                .HasKey(u => u.Uid);

            // Garden
            modelBuilder.Entity<Garden>()
                .HasKey(g => g.Id);

            // Plant
            modelBuilder.Entity<Plant>()
                .HasKey(p => p.Id);

            // Pollinator
            modelBuilder.Entity<Pollinator>()
                .HasKey(p => p.Id);

            // Seed Data
            ModelBuilder.Entity<UserProfile>().HasData(UserProfileData.UserProfiles);
            ModelBuilder.Entity<Garden>().HasData(GardenData.Gardens);
            ModelBuilder.Entity<Plant>().HasData(PlantData.Plants);
            ModelBuilder.Entity<Pollinator>().HasData(PollinatorData.Pollinators);
        }
    }
}
