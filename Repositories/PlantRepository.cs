using Microsoft.EntityFrameworkCore;
using PollinatorBE.Data;
using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly PollinatorBEDbContext _context;

        public PlantRepository(PollinatorBEDbContext context)
        {
            _context = context;
        }

        public async Task<List<Plant>> GetAllPlantsAsync()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task<List<Plant>> GetPlantsByUserUidAsync(string userProfileUid)
        {
            return await _context.Plants
                .Where(u => u.UserProfileUid == userProfileUid)
                .ToListAsync();
        }

        public async Task<List<Plant>> GetPlantsByPollinatorIdAsync(string pollinatorId)
        {
            return await _context.Plants
                .Where(r => r.Pollinators.Any(ri => ri.Id == pollinatorId))
                .ToListAsync();
        }

        public async Task<Plant> GetPlantByIdAsync(string id)
        {
            return await _context.Plants.FindAsync(id);
        }

        public async Task<Plant> CreatePlantAsync(Plant plant)
        {
            var result = await _context.Plants.AddAsync(plant);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Plant?> UpdatePlantAsync(string id, Plant plant)
        {
            var existingPlant = await _context.Plants.FindAsync(id);
            if (existingPlant == null) return null;
            existingPlant.Name = plant.Name;
            existingPlant.UserProfileUid = plant.UserProfileUid;
            existingPlant.Region = plant.Region;
            existingPlant.Season = plant.Season;
            existingPlant.Type = plant.Type;
            existingPlant.Description = plant.Description;
            existingPlant.Picture = plant.Picture;
            existingPlant.Sun = plant.Sun;
            existingPlant.Liked = plant.Liked;
            await _context.SaveChangesAsync();
            return existingPlant;
        }

        public async Task<Plant?> DeletePlantAsync(string id)
        {
            var deletePlant = await _context.Plants.FindAsync(id);
            if (deletePlant == null)
            {
                return null;
            }
            _context.Plants.Remove(deletePlant);
            await _context.SaveChangesAsync();
            return deletePlant;
        }
    }
}
