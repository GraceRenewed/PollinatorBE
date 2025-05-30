﻿using System.ComponentModel.DataAnnotations;

namespace PollinatorBE.Models
{
    public class Garden
    {
        [Key]
        public string Id { get; set; }

        public string? UserProfileUid { get; set; }
        public UserProfile? UserProfile { get; set; }

        [Required]
        public required string Type { get; set; }
        public string? Region { get; set; }
        public string? Season { get; set; }
        public string? Image { get; set; }
        public Boolean Liked { get; set; }
        public string? Notes { get; set; }
        public string? Sun { get; set; }

        public ICollection<GardenPlant> GardenPlants { get; set; } 
        public List<Pollinator> Pollinators { get; set;  } = new List<Pollinator>();
    }
}
