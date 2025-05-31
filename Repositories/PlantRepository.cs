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

        public async Task<Plant> UpdatePlantAsync(string id, Plant plant)
        {
            var existingPlant = await _context.Plants.FindAsync(id);
            if (existingPlant == null) return null;
            existingPlant.Name = plant.Name;
            existingPlant.UserProfileUid = existingPlant.UserProfileUid;
            existingPlant.Region = existingPlant.Region;
            existingPlant.Season = existingPlant.Season;
            existingPlant.Type = existingPlant.Type;
            existingPlant.Description = existingPlant.Description;
            existingPlant.Picture = existingPlant.Picture;
            existingPlant.Sun = existingPlant.Sun;
            existingPlant.Liked = existingPlant.Liked;
            await _context.SaveChangesAsync();
            return existingPlant;
        }

        public async Task<Plant> DeletePlantAsync(string id)
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
