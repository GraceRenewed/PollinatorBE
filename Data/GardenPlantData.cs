using PollinatorBE.Models;

namespace PollinatorBE.Data
{
    public class GardenPlantData
    {
        public static List<GardenPlant> GardenPlants = new ()
        { 
            new ()
            {
                Id = "gp10",
                GardenId = "garden001",
                Garden = new Garden { 
                    Id = "garden001",
                    Type = "Vegetable Garden"
                    },
                PlantId = "plant001",
                Plant = new Plant { 
                    Id = "plant001",
                    Name = "Tomato",
                    Type = "Vegetable",
                    Description = "Juicy red fruit great for salads.",
                    Sun = "Full Sun"
                    },
                UserProfileUid = "user001"
            },

            new ()
            {
                Id = "gp11",
                GardenId = "garden002",
                Garden = new Garden {
                    Id = "garden002",
                    Type = "Pollinator Garden"
                    },
                PlantId = "plant_flp002",
                Plant = new Plant {
                    Id = "plant_flp002",
                    Name = "Mildweed",
                    Type = "Flower",
                    Description = "Essential host plant for monarch butterflies.",
                    Sun = "Full Sun"
                    },
                UserProfileUid = "user002"
            },

            new ()
            {
                Id= "gp12",
                GardenId = "garden003",
                Garden = new Garden {
                    Id = "garden003",
                    Type = "Native Flower Bed"
                    },
                PlantId = "plant_flp003",
                Plant = new Plant {
                    Id = "plant_flp003",
                    Name = "Coneflower",
                    Type = "Flower",
                    Description = "Purple-petaled flower rich in nectar for bees and butterflies.",
                    Sun = "Full Sun"
                    },
                UserProfileUid = "user003"
            },

            new ()
            {
                Id= "gp13",
                GardenId = "garden004",
                Garden = new Garden {
                    Id = "garden004",
                    Type = "Mixed Herb and Flower Garden"
                    },
                PlantId = "plant_flp004",
                Plant = new Plant {
                    Id = "plant_flp004",
                    Name = "Black-eyed Susan",
                    Type = "Flower",
                    Description = "Yellow-petaled wildflower that supports bees and hoverflies.",
                    Sun = "Full Sun"
                    },
                UserProfileUid = "user004"
            },

            new ()
            {
                Id = "gp14",
                GardenId = "garden001",
                Garden = new Garden {
                    Id = "garden001",
                    Type = "Vegetable Garden"
                    },
                PlantId = "plant002",
                Plant = new Plant {
                    Id = "plant002",
                    Name = "Basil",
                    Type = "Vegetable",
                    Description = "Fragrant herb often used in Italian dishes.",
                    Sun = "Partial Sun"
                    },
                UserProfileUid = "user001"
            },
        };
    }
}
