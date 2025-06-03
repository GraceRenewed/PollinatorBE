using Microsoft.EntityFrameworkCore;
using PollinatorBE.Data;
using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Repositories
{
    public class GardenRepository : IGardenRepository
    {
        private readonly PollinatorBEDbContext _context;

        public GardenRepository(PollinatorBEDbContext context)
        {
            _context=context;
        }

        public async Task<List<Garden>> GetAllGardensAsync()
        {
            return await _context.Gardens.ToListAsync();
        }

        public async Task<Garden> GetGardenByIdAsync(string id)
        {
            return await _context.Gardens.FindAsync(id);
        }

        public async Task<List<Garden>> GetGardensByUserIdAsync(string userProfileUid)
        {
            return await _context.Gardens
                .Where(u => u.UserProfileUid == userProfileUid)
                .ToListAsync();
        }

        public async Task<Garden> CreateGardenAsync(Garden garden)
        {
            var gResult = await _context.Gardens.AddAsync(garden);
            await _context.SaveChangesAsync();
            return gResult.Entity;
        }

        public async Task<Garden?> UpdateGardenAsync(string id, Garden garden)
        {
            var existingGarden = await _context.Gardens.FindAsync(id);
            if (existingGarden == null) 
                return null;
            existingGarden.UserProfileUid = garden.UserProfileUid;
            existingGarden.Type = garden.Type;
            existingGarden.Region = garden.Region;
            existingGarden.Season = garden.Season;
            existingGarden.Image = garden.Image;
            existingGarden.Liked = garden.Liked;
            existingGarden.Notes = garden.Notes;
            existingGarden.Sun = garden.Sun;
            await _context.SaveChangesAsync();
            return existingGarden;
        }

        public async Task<Garden> DeleteGardenAsync(string id)
        {
            var deletePlant = await _context.Gardens.FindAsync(id);
            if (deletePlant == null)
            {
                return null;
            }
            _context.Gardens.Remove(deletePlant);
            await _context.SaveChangesAsync();
            return deletePlant;
        }
    }   
}
