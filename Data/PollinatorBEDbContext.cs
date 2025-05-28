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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UserProfile
            modelBuilder.Entity<UserProfile>()
                .HasKey(u => u.Uid);

            // Garden
            modelBuilder.Entity<Garden>()
                .HasMany(r => r.Pollinators)
                .WithMany(g => g.Gardens);

            // Plant
            modelBuilder.Entity<Plant>()
                .HasMany(g => g.Gardens)
                .WithMany(p => p.Plants);

            // Pollinator
            modelBuilder.Entity<Pollinator>()
                .HasMany(p => p.Plants)
                .WithMany(r => r.Pollinators);

            // Seed Data
            modelBuilder.Entity<UserProfile>().HasData(UserProfileData.UserProfiles);
            modelBuilder.Entity<Garden>().HasData(GardenData.Gardens);
            modelBuilder.Entity<Plant>().HasData(PlantData.Plants);
            modelBuilder.Entity<Pollinator>().HasData(PollinatorData.Pollinators);

           //  modelBuilder.Entity("GardenPollinators").HasData(
               // new { PollinatorId = 1, GardenId = 1 },
                // new { PollinatorId = 1, GardenId = 2 },
                // new { PollinatorId = 2, GardenId = 3 }
           // );
        }
    }
}
