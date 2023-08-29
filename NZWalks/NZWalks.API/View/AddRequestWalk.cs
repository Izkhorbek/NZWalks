using NZWalks.API.Models.Domain;

namespace NZWalks.API.View
{
    public class AddRequestWalk
    {
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        //// Navigation to other Models
        //public Region Region { get; set; }
        //public WalkDifficulty WalkDifficulty { get; set; }
    }
}
