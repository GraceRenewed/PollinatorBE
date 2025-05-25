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

        public async Task<List<Pollinator>> GetPollinatorByPlantIdAsync(string plantId)
        {
            return await _pollinatorRepository.GetPollinatorsByPlantIdAsync(plantId);
        }

    //public async Task<List<Pollinator>> return await
    // public async Task<Pollinator> return await
    // public async Task<Pollinator> return await
    // public async Task<Pollinator> return await
    // public async Task<Pollinator> return await

}
}
