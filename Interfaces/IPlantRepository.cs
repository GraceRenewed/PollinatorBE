using PollinatorBE.Models;

namespace PollinatorBE.Interfaces
{
    public interface IPlantRepository
    {
        Task<List<Plant>> GetAllPlantsAsync();
        Task<List<Plant>> GetPlantsByUserUidAsync(string userUid);
        Task<List<Plant>> GetPlantsByGardenIdAsync(string gardenId);
        Task<List<Plant>> GetPlantsByPollinatorIdAsync(string pollinatorId);
        Task<Plant> GetPlantByIdAsync(string id);
        Task<Plant> CreatePlantAsync(Plant plant);
        Task<Plant> UpdatePlantAsync(string id, Plant plant);
        Task<Plant> DeletePlantAsync(string id);
    }
}
