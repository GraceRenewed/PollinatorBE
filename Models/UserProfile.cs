using System.ComponentModel.DataAnnotations;

namespace PollinatorBE.Models
{
    public class UserProfile
    {
        [Key]
        public string Uid { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Customer user name cannot be longer than 50 characters")]
        public required string UserName { get; set; }
        
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        
        public string? Image {  get; set; }
        public string? Region { get; set; }
        public List<Garden> Gardens { get; set; } = new List<Garden>();
    }
}
