using System.ComponentModel.DataAnnotations;

namespace PollinatorBE.Models
{
    public class Garden
    {
        public required string Id { get; set; }

        public string? UserProfileUid { get; set; }
        public UserProfile? UserProfile { get; set; }

        public string? PlantId { get; set; }
        public Plant? Plant { get; set; }

        public string? PollinatorId { get; set; }
        public Pollinator? Pollinator { get; set; }

        [Required]
        public required string type { get; set; }
        public string? Region { get; set; }
        public string? Season { get; set; }
        public string? Image { get; set; }
        public Boolean Liked { get; set; }
        public string? Notes { get; set; }
        public string? Sun { get; set; }
    }
}
