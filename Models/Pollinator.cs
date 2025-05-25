using System.ComponentModel.DataAnnotations;

namespace PollinatorBE.Models
{
    public class Pollinator
    {
        [Key]
        public required string Id { get; set; }

        public string? UserProfileUid { get; set; }
        public UserProfile? UserProfile { get; set; }

        public string? GardenId { get; set; }
        public Garden? Garden { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Region { get; set; }
        public string? Season { get; set; }

        [Required]
        public required string Description { get; set; }
        public string? Image { get; set; }
        public Boolean Liked { get; set; }
        public List<Plant> Plants { get; set; } = new List<Plant>();
    }
}
