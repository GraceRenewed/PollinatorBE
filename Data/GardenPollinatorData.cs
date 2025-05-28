using PollinatorBE.Models;

namespace PollinatorBE.Data
{
    public class GardenPollinatorData
    {
        public static List<GardenPollinator> GardenPollinators = new()
        {
        new ()
        {
            Id = 100,
            GardenId = "garden001",
            PollinatorId = "poll001, poll002",
            UserProfileUid = "user001",
        },
        new ()
        {
            Id = 200,
            GardenId = "garden002",
            PollinatorId = "poll003",
            UserProfileUid = "user002",
        },
        new()
        {
            Id = 300,
            GardenId = "garden003",
            PollinatorId = "poll004",
            UserProfileUid = "user003",
        }
        };
    }
}
