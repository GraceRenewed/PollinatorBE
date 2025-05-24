using PollinatorBE.Models;

namespace PollinatorBE.Interfaces
{
    public interface IUserProfileRepository
    {
        // An interface is a contract that defines the signature of the functionality.
        // It defines a set of methods that a class that inherits the interface MUST implement.
        // The interface is a mechanism to achieve abstraction.
        // Interfaces can be used in unit testing to mock out the actual implementation.   
        Task<List<UserProfile>> GetUserProfilesAsync();
        Task<UserProfile> GetUserByUidAsync(string uid);
        Task<UserProfile> CreateUserByUidAsync(UserProfile userProfile);
        Task<UserProfile> UpdateUserByUidAsync(string uid, UserProfile userProfile);
        Task<UserProfile> DeleteUserByUidAsync(string uid);
    }
}
