using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO
{
    public class WalkDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthLnKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        // Navigation to other Models
        public WalkDifficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
