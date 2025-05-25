using PollinatorBE.Models;

namespace PollinatorBE.Interfaces
{
    public interface IUserProfileServices
    {
        // responsible for processing business logic
        // will call the repository layer to do the actual CRUD operations
        // Defines the contract or all the methods that will be inherited by class
        // Makes call to Repository
        // Just method definitions, implementation done in userprofile Service
        Task<List<UserProfile>> GetUserProfilesAsync();
        Task<UserProfile> GetUserByUidAsync(string uid);
        Task<UserProfile> CreateUserByUidAsync(UserProfile userProfile);
        Task<UserProfile> UpdateUserByUidAsync(string uid, UserProfile userProfile);
        Task<UserProfile> DeleteUserByUidAsync(string uid);
    }
}
