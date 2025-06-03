using Microsoft.EntityFrameworkCore;
using PollinatorBE.Data;
using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Repositories
{
    public class PollinatorRepository : IPollinatorRepository
    {
        private readonly PollinatorBEDbContext _context;

        public PollinatorRepository(PollinatorBEDbContext context)
        {
            _context=context;
        }

        public async Task<List<Pollinator>> GetAllPollinatorsAsync()
        {
            return await _context.Pollinators.ToListAsync();
        }

        public async Task<List<Pollinator>> GetPollinatorsByPlantIdAsync(string plantId)
        {
            return await _context.Pollinators
                .Where(p =>p.Plants.Any(pl => pl.Id == plantId))
                .ToListAsync();
        }

        public async Task<List<Pollinator>> GetPollinatorsByGardenIdAsync(string gardenId)
        {
            return await _context.Pollinators
                .Where(g =>g.Gardens.Any(gi => gi.Id == gardenId))
                .ToListAsync();
        }

        public async Task<Pollinator> GetPollinatorByIdAsync(string id)
        {
            return await _context.Pollinators.FindAsync(id);
        }

        public async Task<Pollinator> CreatePollinatorAsync(Pollinator pollinator)
        {
            var result = await _context.Pollinators.AddAsync(pollinator);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Pollinator?> UpdatePollinatorAsync(string id, Pollinator pollinator)
        {
            var existingPollinator = await _context.Pollinators.FindAsync(id);
            if (existingPollinator == null) return null;
            existingPollinator.UserProfileUid = pollinator.UserProfileUid;
            existingPollinator.Name = pollinator.Name;
            existingPollinator.Region = pollinator.Region;
            existingPollinator.Season = pollinator.Season;
            existingPollinator.Description = pollinator.Description;
            existingPollinator.Image = pollinator.Image;
            existingPollinator.Liked = pollinator.Liked;
            await _context.SaveChangesAsync();
            return existingPollinator;
        }

        public async Task<Pollinator> DeletePollinatorAsync(string id)
        {
            var deletePollinator = await _context.Pollinators.FindAsync(id);
            if (deletePollinator == null)
            {
                return null;
            }
            _context.Pollinators.Remove(deletePollinator);
            await _context.SaveChangesAsync();
            return deletePollinator;
        }
    }
}
