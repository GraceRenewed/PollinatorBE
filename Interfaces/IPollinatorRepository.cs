using PollinatorBE.Models;

namespace PollinatorBE.Interfaces
{
    public interface IPollinatorRepository
    {
        Task<List<Pollinator>> GetAllPollinatorsAsync();
        Task<List<Pollinator>> GetPollinatorsByPlantIdAsync(string plantId);
        Task<List<Pollinator>> GetPollinatorsByGardenIdAsync(string gardenId);
        Task<Pollinator> GetPollinatorByIdAsync(string id);
        Task<Pollinator> CreatePollinatorAsync(Pollinator pollinator);
        Task<Pollinator> UpdatePollinatorAsync(string id, Pollinator pollinator);
        Task<Pollinator> DeletePollinatorAsync(string id);
    }
}
