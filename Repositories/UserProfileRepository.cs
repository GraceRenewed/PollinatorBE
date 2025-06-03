using Microsoft.EntityFrameworkCore;
using PollinatorBE.Data;
using PollinatorBE.Interfaces;
using PollinatorBE.Models;

namespace PollinatorBE.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly PollinatorBEDbContext _context;

        public UserProfileRepository(PollinatorBEDbContext context)
        {
            _context=context;
        }

        public async Task<List<UserProfile>> GetUserProfilesAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetUserByUidAsync(string uid)
        {
            return await _context.UserProfiles.FindAsync(uid);
        }

        public async Task<UserProfile> CreateUserProfileAsync(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;
        }

        public async Task<UserProfile?> UpdateUserAsync(string uid, UserProfile userProfile)
        {
            var existingUserProfile = await _context.UserProfiles.FindAsync(uid);
            if (existingUserProfile == null)
            {
                return null;
            }
            existingUserProfile.UserName = userProfile.UserName;
            existingUserProfile.Email = userProfile.Email;
            existingUserProfile.Image = userProfile.Image;
            existingUserProfile.Region = userProfile.Region;
            await _context.SaveChangesAsync();
            return userProfile;
        }
        public async Task<UserProfile> DeleteUserAsync(string uid)
        {
            var userProfile = await _context.UserProfiles.FindAsync(uid);
            if (userProfile == null)
            {
                return null;
            }
            _context.UserProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;
        }
    }
}
