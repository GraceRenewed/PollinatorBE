using PollinatorBE.Models;

namespace PollinatorBE.Data
{
    public class GardenPlantData
    {
        public static List<GardenPlant> GardenPlants = new()
        {
            new ()
            {
                Id = 10,
                GardenId = "garden001",
                PlantId = "plant001, plant002",
            },

            new ()
            {
                Id = 11,
                GardenId = "garden002",
                PlantId = "plant_flp002",

            },

            new ()
            {
                Id= 12,
                GardenId = "garden003",
                PlantId = "plant_flp003",
            },

            new ()
            {
                Id= 13,
                GardenId = "garden004",
                PlantId = "plant_flp004",
            },
        };
    }
}
