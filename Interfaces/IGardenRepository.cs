using PollinatorBE.Models; 

namespace PollinatorBE.Interfaces
{
    public interface IGardenRepository
    {
        Task<List<Garden>> GetAllGardensAsync();
        Task<List<Garden>> GetGardenByIdAsync(string id);
        Task<List<Garden>> GetGardenByUserIdAsync(string userId);
        Task<Garden> CreateGardenAsync(Garden garden);
        Task<Garden> UpdateGardenAsync(string id, Garden garden);
        Task<Garden> DeleteGardenAsync(string id);
    }
}
