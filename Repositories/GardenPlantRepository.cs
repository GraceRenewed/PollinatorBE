using Microsoft.EntityFrameworkCore;
using PollinatorBE.Data;
using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Repositories
{
    public class GardenPlantRepository : IGardenPlantRepository
    {
        private readonly PollinatorBEDbContext _context;

        public GardenPlantRepository(PollinatorBEDbContext context)
        {
            _context=context;
        }

        public async Task<List<GardenPlant>> GetGardenPlantsAsync()
        {
            return await _context.GardenPlants.ToListAsync();
        }

        public async Task<GardenPlant> GetGardenPlantsByIdAsync(string id)
        {
            return await _context.GardenPlants.FindAsync(id);
        }

        public async Task<GardenPlant> CreateGardenPlantsAsync(GardenPlant gardenPlant)
        {
            var gpResult = await _context.GardenPlants.AddAsync(gardenPlant);
            await _context.SaveChangesAsync();
            return gpResult.Entity;
        }

        public async Task<GardenPlant> UpdateGardenPlantAsync(string id, GardenPlant gardenPlant)
        {
            var existingGPlant = await _context.GardenPlants.FindAsync(id);
            if (existingGPlant == null) return null;
            existingGPlant.GardenId = existingGPlant.GardenId;
            existingGPlant.PlantId = existingGPlant.PlantId;
            existingGPlant.UserProfileUid = existingGPlant.UserProfileUid;
            await _context.SaveChangesAsync();
            return existingGPlant;
        }

        // public async Task DeleteGardenPlantAsync(string id)
        // {
         //   var deleteGPlant = await _context.GardenPlants.FindAsync(id);
         //   if (deleteGPlant == null)
         //   {
         //       return null;
         //   }
         //   _context.GardenPlants.Remove(deleteGPlant);
        //    await _context.SaveChangesAsync();
         //   return deleteGPlant;
        // }
    }
}
