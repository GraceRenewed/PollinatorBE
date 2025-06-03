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
        public DbSet<GardenPlant> GardenPlants { get; set; }

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
                .HasKey(g => g.Id);

            // Plant
            modelBuilder.Entity<Plant>()
                .HasKey(p => p.Id);

            // Pollinator
            modelBuilder.Entity<Pollinator>()
                .HasMany(p => p.Plants)
                .WithMany(r => r.Pollinators);

            modelBuilder.Entity<GardenPlant>()
                .HasKey(gp => gp.Id);

            modelBuilder.Entity<GardenPlant>()
                .HasIndex(gp => new { gp.GardenId, gp.PlantId }).IsUnique();

            modelBuilder.Entity<GardenPlant>()
                .HasOne(gp => gp.Garden)
                .WithMany(g => g.GardenPlants)
                .HasForeignKey(gp => gp.GardenId);

            modelBuilder.Entity<GardenPlant>()
                .HasOne(gp => gp.Plant)
                .WithMany(p => p.GardenPlants)
                .HasForeignKey(gp => gp.PlantId);

            // Seed Data
            modelBuilder.Entity<UserProfile>().HasData(UserProfileData.UserProfiles);
            modelBuilder.Entity<Garden>().HasData(GardenData.Gardens);
            modelBuilder.Entity<Plant>().HasData(PlantData.Plants);
            modelBuilder.Entity<Pollinator>().HasData(PollinatorData.Pollinators);
            modelBuilder.Entity<GardenPlant>().HasData(GardenPlantData.GardenPlants);

        }

    }
}
