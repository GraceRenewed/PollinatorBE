using PollinatorBE.Models;

namespace PollinatorBE.Interfaces
{
    public interface IGardenPlantRepository
    {
        Task<List<GardenPlant>> GetGardenPlantsAsync();
        Task<List<GardenPlant>> GetGardenPlantsByIdAsync(string gardenId);
        Task<GardenPlant> CreateGardenPlantsAsync(GardenPlant gardenPlant);
        Task<GardenPlant?> UpdateGardenPlantAsync(string id, GardenPlant gardenPlant);
        Task<GardenPlant> DeleteGardenPlantAsync(string id);
    }
}

