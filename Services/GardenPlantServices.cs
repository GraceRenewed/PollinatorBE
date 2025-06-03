using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Services
{
    public class GardenPlantServices : IGardenPlantServices
    {
        private readonly IGardenPlantRepository _gardenPlantRepository;

        public GardenPlantServices(IGardenPlantRepository gardenPlantRepository)
        {
            _gardenPlantRepository = gardenPlantRepository;
        }

        public async Task<List<GardenPlant>> GetGardenPlantsAsync()
        {
            return await _gardenPlantRepository.GetGardenPlantsAsync();
        }

        public async Task<List<GardenPlant>> GetGardenPlantsByIdAsync(string gardenId)
        {
            return await _gardenPlantRepository.GetGardenPlantsByIdAsync(gardenId);
        }

        public async Task<GardenPlant> CreateGardenPlantsAsync(GardenPlant gardenPlant)
        {
            return await _gardenPlantRepository.CreateGardenPlantsAsync(gardenPlant);
        }

        public async Task<GardenPlant?> UpdateGardenPlantAsync(string id, GardenPlant gardenPlant)
        {
            return await _gardenPlantRepository.UpdateGardenPlantAsync(id, gardenPlant);
        }

        public async Task<GardenPlant?> DeleteGardenPlantAsync(string id)
        {
            return await _gardenPlantRepository.DeleteGardenPlantAsync(id);
        }
    }
}
