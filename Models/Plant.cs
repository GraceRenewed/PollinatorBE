using System.ComponentModel.DataAnnotations;

namespace PollinatorBE.Models
{
    public class Plant
    {
        [Key]
        public required string Id {  get; set; }
        
        public string? UserProfileUid { get; set; }
        public UserProfile? UserProfile { get; set; }

        public required string Name {  get; set; }
        public string? Region { get; set; }
        public string? Season { get; set; }
        
        [Required]
        public required string Type { get; set; }
        
        [Required]
        public required string Description { get; set; }
        public string? Picture {  get; set; }
        
        [Required]
        public required string Sun { get; set; }
        [Required]
          
        public Boolean Liked { get; set; }
        public List<Pollinator> Pollinators { get; set; } = new List<Pollinator>();
        public List<Garden> Gardens { get; set;  } = new List<Garden>();
    }
}
