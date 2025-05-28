using PollinatorBE.Models;

namespace PollinatorBE.Data
{
    public class PlantPollinatorData
    {
        public static List<PlantPollinator> PlantPollinators = new()
        {
            new ()
            {
                Id = 1000,
                PlantId = "plant001",
                PollinatorId = "poll002",
            },
            new ()
            {
                Id = 2000,
                PlantId = "plant_flp001",
                PollinatorId = "poll003, poll001, poll002, poll004"
            },
            new ()
            {
                Id = 3000,
                PlantId = "plant_flp002",
                PollinatorId = "poll003, poll001, poll002, poll004",
            },
            new ()
            {
                PlantId = "plant_flp004, plant_flp003, plant_flp002, plant_flp001, plant001",
                PollinatorId = "poll002"
            },
        };
    }
}
