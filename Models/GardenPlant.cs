using System.ComponentModel.DataAnnotations;

namespace PollinatorBE.Models
{
    public class GardenPlant
    {
        [Key]
        public required string Id { get; set; }

        [Required]
        public string GardenId { get; set; }
        public Garden? Garden { get; set; }

        [Required]
        public string PlantId { get; set; }
        public Plant? Plant { get; set; }

        public string? UserProfileUid { get; set; }
        public UserProfile? UserProfile { get; set; }

    }
}