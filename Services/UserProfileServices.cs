using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Services
{
    public class UserProfileServices : IUserProfileServices
    {
        // The service layer is responsible for processing business logic.
        // Right now, the service layer is just calling the repository layer.
        // The service layer will call the repository layer to do the actual CRUD operations.
        // The service layer will return the data to the endpoint (controller).
        private readonly IUserProfileRepository _userProfileRepository;

        // This constructor is used for dependency injection.
        // We are injecting the IWeatherForecastRepository interface into the WeatherForecastService class.
        // We inject the repository interface instead of the actual repository class.
        // This is because we can easily mock the interface for unit testing.
        // It also makes our code more flexible and easier to maintain.
        // The type of DI used here is called constructor injection.
        public UserProfileServices(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        // async means that the method is asynchronous.
        // async methods can be awaited using the await keyword.
        // async methods return a Task or Task<T>.
        // Task represents an asynchronous operation that can return a value.
        // Task<T> is a task that returns a value.
        // To get the value, we use the await keyword.
        public async Task<UserProfile> GetUserByUidAsync(string uid)
        {
            return await _userProfileRepository.GetUserByUidAsync(uid);
        }

        public async Task<List<UserProfile>> GetUserProfilesAsync()
        {
            return await _userProfileRepository.GetUserProfilesAsync();
        }

        public async Task<UserProfile> CreateUserProfileAsync(UserProfile userProfile)
        {
            return await _userProfileRepository.CreateUserProfileAsync(userProfile);
        }

        public async Task<UserProfile?> UpdateUserAsync(string uid, UserProfile userProfile)
        {
            return await _userProfileRepository.UpdateUserAsync(uid, userProfile);
        }

        public async Task<UserProfile?> DeleteUserAsync(string uid)
        {
            return await _userProfileRepository.DeleteUserAsync(uid);
        }
    }
}
