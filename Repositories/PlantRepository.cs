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
                .Where(p => p.UserProfileUid == userProfileUid)
                .ToListAsync();
        }

        public async Task<List<Plant>> GetPlantsByGardenIdAsync(string gardenId)
        {
            return await _context.Plants
                .Where(g => g.GardenId == gardenId)
                .ToListAsync();
        }

        public async Task<List<Plant>> GetPlantsByPollinatorIdAsync(string pollinatorId)
        { 
            return await _context.Plants
                .Where(r => r.PollinatorId == pollinatorId)

                .ToListAsync();
        }   
    }
}
