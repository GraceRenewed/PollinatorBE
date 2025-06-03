using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Services
{
    public class PlantServices : IPlantServices
    {
        private readonly IPlantRepository _plantRepository;

        public PlantServices(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<List<Plant>> GetAllPlantsAsync()
        {
            return await _plantRepository.GetAllPlantsAsync();
        }

        public async Task<List<Plant>> GetPlantsByUserUidAsync(string userProfileUid)
        {
            return await _plantRepository.GetPlantsByUserUidAsync(userProfileUid);
        }

        public async Task<List<Plant>> GetPlantsByPollinatorIdAsync(string pollinatorId)
        {
            return await _plantRepository.GetPlantsByPollinatorIdAsync(pollinatorId);
        }

        public async Task<Plant> GetPlantByIdAsync(string id)
        {
            return await _plantRepository.GetPlantByIdAsync(id);
        }

        public async Task<Plant> CreatePlantAsync(Plant plant)
        {
            return await _plantRepository.CreatePlantAsync(plant);
        }

        public async Task<Plant?> UpdatePlantAsync(string id, Plant plant)
        {
            return await _plantRepository.UpdatePlantAsync(id, plant);
        }

        public async Task<Plant?> DeletePlantAsync(string id)
        {
            return await _plantRepository.DeletePlantAsync(id);
        }
    }
}
