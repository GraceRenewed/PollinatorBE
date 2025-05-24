using PollinatorBE.Models;

namespace PollinatorBE.Data
{
    public class UserProfileData
    {
        public static List<UserProfile> UserProfiles = new()
        {
            new()
            {
                Uid = "user001",
                UserName = "GardenGuru",
                Email = "garden.guru@example.com",
                Image = "https://example.com/images/user12345.jpg",
                Region = "Pacific Northwest",
            },

            new()
            {
                Uid = "user002",
                UserName = "GreenThumb01",
                Email = "greenthumb01@example.com",
                Image = "https://example.com/images/user001.jpg",
                Region = "Pacific Northwest",
            },
            new()
            {
                Uid = "user003",
                UserName = "UrbanGardener",
                Email = "urban.gardener@example.com",
                Image = "https://example.com/images/user002.jpg",
                Region = "Midwest"
            },
            new()
            {
                Uid = "user004",
                UserName = "NatureNerd",
                Email = "naturenerd@example.com",
                Image = "https://example.com/images/user003.jpg",
                Region = "Southeast"
            },
            new()
            {
                Uid = "user005",
                UserName = "FloraFan",
                Email = "florafan@example.com",
                Image = "https://example.com/images/user004.jpg",
                Region = "Southwest"
            },
        };
    }
}
