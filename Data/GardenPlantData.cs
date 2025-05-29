using PollinatorBE.Models;

namespace PollinatorBE.Data
{
    public class GardenPlantData
    {
        public static List<GardenPlant> GardenPlants = new List<GardenPlant>
        { 
            new ()
            {
                Id = "gp10",
                GardenId = "garden001",
                PlantId = "plant001, plant002",
                UserProfileUid = "user001"
            },

            new ()
            {
                Id = "gp11",
                GardenId = "garden002",
                PlantId = "plant_flp002",
                UserProfileUid = "user002"
            },

            new ()
            {
                Id= "gp12",
                GardenId = "garden003",
                PlantId = "plant_flp003",
                UserProfileUid = "user003"
            },

            new ()
            {
                Id= "gp13",
                GardenId = "garden004",
                PlantId = "plant_flp004",
                UserProfileUid = "user004"
            },
        };
    }
}
