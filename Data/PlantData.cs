using PollinatorBE.Models;

namespace PollinatorBE.Data
{
    public class PlantData
    {
        public static List<Plant> Plants = new()
        {
        new () {
            Id = "plant001",
            UserProfileUid = "user001",
            Name = "Tomato",
            Region = "Pacific Northwest",
            Season = "Summer",
            Type = "Vegetable",
            Description = "Juicy red fruit great for salads.",
            Picture = "https://example.com/images/tomato.jpg",
            Sun = "Full Sun",
            Liked = true,
            },
        new() {
            Id = "plant002",
            UserProfileUid = "user001",
            Name = "Basil",
            Region = "Pacific Northwest",
            Season = "Summer",
            Type = "Herb",
            Description = "Fragrant herb often used in Italian dishes.",
            Picture = "https://example.com/images/basil.jpg",
            Sun = "Partial Sun",
            Liked = false,
            },
        new() {
            Id = "plant_flp001",
            UserProfileUid = "user001",
            Name = "Bee Balm",
            Region = "Northeast",
            Season = "Summer",
            Type = "Flower",
            Description = "Tubular red and pink blooms that attract bees and hummingbirds.",
            Picture = "https://example.com/images/beebalm.jpg",
            Sun = "Full Sun",
            Liked = true,
            },
        new() {
            Id = "plant_flp002",
            UserProfileUid = "user002",
            Name = "Milkweed",
            Region = "Midwest",
            Season = "Summer",
            Type = "Flower",
            Description = "Essential host plant for monarch butterflies.",
            Picture = "https://example.com/images/milkweed.jpg",
            Sun = "Full Sun",
            Liked = true,
            },
        new() {
            Id = "plant_flp003",
            UserProfileUid = "user003",
            Name = "Coneflower",
            Region = "Southeast",
            Season = "Summer",
            Type = "Flower",
            Description = "Purple-petaled flower rich in nectar for bees and butterflies.",
            Picture = "https://example.com/images/coneflower.jpg",
            Sun = "Full Sun",
            Liked = true,
            },
        new() {
            Id = "plant_flp004",
            UserProfileUid = "user004",
            Name = "Black-eyed Susan",
            Region = "Southwest",
            Season = "Summer",
            Type = "Flower",
            Description = "Yellow-petaled wildflower that supports bees and hoverflies.",
            Picture = "https://example.com/images/blackeyedsusan.jpg",
            Sun = "Full Sun",
            Liked = false,
            }
        };
    }
}
