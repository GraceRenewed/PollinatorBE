using PollinatorBE.Models;

namespace PollinatorBE.Data
{
    public class PollinatorData
    {
        public static List<Pollinator> Pollinators = new()
        {
            new() {
            Id = "poll001",
            UserProfileUid = "user001",
            Name = "Honey Bee",
            Region = "Pacific Northwest",
            Season = "Spring to Fall",
            Description = "Essential pollinator for fruits, vegetables, and herbs.",
            Image = "https://example.com/images/honeybee.jpg",
            Liked = true,
            },
        new() {
            Id = "poll002",
            UserProfileUid = "user001",
            Name = "Bumblebee",
            Region = "Pacific Northwest",
            Season = "Spring to Fall",
            Description = "Fuzzy, robust bee that pollinates tomatoes and native flowers.",
            Image = "https://example.com/images/bumblebee.jpg",
            Liked = false,
            },
        new() {
            Id = "poll003",
            UserProfileUid = "user002",
            Name = "Monarch Butterfly",
            Region = "Midwest",
            Season = "Summer",
            Description = "Iconic butterfly species reliant on milkweed for reproduction.",
            Image = "https://example.com/images/monarch.jpg",
            Liked = true,
            },
        new() {
            Id = "poll004",
            UserProfileUid = "user003",
            Name = "Painted Lady Butterfly",
            Region = "Southeast",
            Season = "Summer",
            Description = "Colorful butterfly that loves coneflowers and thistles.",
            Image = "https://example.com/images/paintedlady.jpg", 
            Liked = true,
            }
        };
    }
}
