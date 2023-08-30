using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.View;

namespace NZWalks.API.Repository
{
    public interface IRepositoryWalkDifficulty
    {
        Task<IEnumerable<WalkDifficulty>> GetWalkDifficultyAsync();

        Task<WalkDifficulty> GetWalkDifficultybyId(Guid id);

        Task<WalkDifficulty> AddWalkDifficulty(WalkDifficultyDto difficultydto);

        Task<WalkDifficulty> DeleteWalkDifficulty(Guid id);

        Task<WalkDifficulty> UpdateWalkDifficulty(Guid id, WalkDifficultyDto walkDifficultyDto);

    }
}
