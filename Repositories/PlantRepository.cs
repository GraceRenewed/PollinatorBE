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
    }
}
