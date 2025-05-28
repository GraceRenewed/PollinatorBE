using System.ComponentModel.DataAnnotations;

namespace PollinatorBE.Models
{
    public class GardenPlant
    {
        public required int Id { get; set; }

        public required string GardenId { get; set; }
        public required Garden Garden { get; set; }

        public required string PlantId {  get; set; }
        public required Plant Plant { get; set; }

        public string? UserProfileUid { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}
