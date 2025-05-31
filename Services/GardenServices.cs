using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Services
{
    public class GardenServices : IGardenServices
    {
        private readonly IGardenRepository _gardenRepository;

        public GardenServices(IGardenRepository gardenRepository)
        {
            _gardenRepository = gardenRepository;
        }

        public async Task<List<Garden>> GetAllGardensAsync()
        {
            return await _gardenRepository.GetAllGardensAsync();
        }

        public async Task<Garden> GetGardenByIdAsync(string id)
        {
            return await _gardenRepository.GetGardenByIdAsync(id);
        }

        public async Task<List<Garden>> GetGardensByUserIdAsync(string userProfileId)
        {
            return await _gardenRepository.GetGardensByUserIdAsync(userProfileId);
        }
            
        public async Task<Garden> CreateGardenAsync(Garden garden)
        {
            return await _gardenRepository.CreateGardenAsync(garden);
        }
        public async Task<Garden> UpdateGardenAsync(string id, Garden garden)
        {
            return await _gardenRepository.UpdateGardenAsync(id, garden);
        }

        public async Task<Garden> DeleteGardenAsync(string id)
        {
            return await _gardenRepository.DeleteGardenAsync(id);
        }
    }
}
