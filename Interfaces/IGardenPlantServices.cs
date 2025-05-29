using PollinatorBE.Models;

namespace PollinatorBE.Interfaces
{
    public interface IGardenPlantServices
    {
        Task<List<GardenPlant>> GetGardenPlantsAsync();
        Task<GardenPlant> GetGardenPlantsByIdAsync(string id);
        Task<GardenPlant> CreateGardenPlantsAsync(GardenPlant gardenPlant);
        Task<GardenPlant> UpdateGardenPlantAsync(string id, GardenPlant gardenPlant);
        Task DeleteGardenPlantAsync(string id);
    }
}
