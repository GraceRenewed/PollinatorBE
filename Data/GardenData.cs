using PollinatorBE.Models;

namespace PollinatorBE.Data
{
    public class GardenData
    {
        public static List<Garden> Gardens = new()
        {
            new() {
                Id = "garden001",
                UserProfileUid = "user001",
                Type = "Vegetable Garden",
                Region = "Pacific Northwest",
                Season = "Summer",
                Image = "https://example.com/images/garden001.jpg",
                Liked = true,
                Notes = "Best spot for tomatoes and basil.",
                Sun = "Full Sun"
                },
            new() {
                Id = "garden002",
                UserProfileUid = "user002",
                Type = "Pollinator Garden",
                Region = "Midwest",
                Season = "Summer",
                Image = "https://example.com/images/garden002.jpg",
                Liked = true,
                Notes = "Milkweed thriving. Monarchs spotted daily.",
                Sun = "Full Sun"
                },
            new() {
                Id = "garden003",
                UserProfileUid = "user003",
                Type = "Native Flower Bed",
                Region = "Southeast",
                Season = "Spring",
                Image = "https://example.com/images/garden003.jpg",
                Liked = false,
                Notes = "Great bee and butterfly activity.",
                Sun = "Partial Sun"
                },
            new() {
                Id = "garden004",
                UserProfileUid = "user004",
                Type = "Mixed Herb and Flower Garden",
                Region = "Southwest",
                Season = "Spring",
                Image = "https://example.com/images/garden004.jpg",
                Liked = true,
                Notes = "Oregano and black-eyed Susans doing well.",
                Sun = "Full Sun"
                }
        };
    }
}
