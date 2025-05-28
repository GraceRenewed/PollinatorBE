using System.ComponentModel.DataAnnotations;

namespace PollinatorBE.Models
{
    public class PlantPollinator
    {
        public required int Id { get; set; }

        public required string PlantId { get; set; }
        public required Plant Plant { get; set; }

        public required string PollinatorId { get; set; }
        public required Pollinator Pollinator { get; set; }
    }
}
