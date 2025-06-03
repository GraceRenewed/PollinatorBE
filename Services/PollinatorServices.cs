using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Services
{
    public class PollinatorServices : IPollinatorServices
    {
        private readonly IPollinatorRepository _pollinatorRepository;

        public PollinatorServices(IPollinatorRepository pollinatorRepository)
        {
            _pollinatorRepository = pollinatorRepository;
        }

        public async Task<List<Pollinator>> GetAllPollinatorsAsync()
        {
            return await _pollinatorRepository.GetAllPollinatorsAsync();
        }

        public async Task<List<Pollinator>> GetPollinatorsByPlantIdAsync(string plantId)
        {
            return await _pollinatorRepository.GetPollinatorsByPlantIdAsync(plantId);
        }

        public async Task<List<Pollinator>> GetPollinatorsByGardenIdAsync(string gardenId)
        {
            return await _pollinatorRepository.GetPollinatorsByGardenIdAsync(gardenId);
        }
        
        public async Task<Pollinator> GetPollinatorByIdAsync(string id)
        {
            return await _pollinatorRepository.GetPollinatorByIdAsync(id);
        }

        public async Task<Pollinator> CreatePollinatorAsync(Pollinator pollinator)
        {
            return await _pollinatorRepository.CreatePollinatorAsync(pollinator);
        }

        public async Task<Pollinator?> UpdatePollinatorAsync(string id, Pollinator pollinator)
        {
            return await _pollinatorRepository.UpdatePollinatorAsync(id, pollinator);
        }

        public async Task<Pollinator?> DeletePollinatorAsync(string id)
        {
            return await _pollinatorRepository.DeletePollinatorAsync(id);
        }

    }
}
