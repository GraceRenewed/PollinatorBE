using System.ComponentModel.DataAnnotations;

namespace PollinatorBE.Models
{
    public class GardenPollinator
    {
       public required int Id { get; set; }

        public required string GardenId { get; set; }
        public required Garden Garden { get; set; }

        public required string PollinatorId { get; set; }
        public required Pollinator Pollinator { get; set; }

        public string? UserProfileUid { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}
