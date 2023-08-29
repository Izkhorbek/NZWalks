using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.View;

namespace NZWalks.API.Repository
{
    public interface IRepositoryWalk
    {
        Task<IEnumerable<Walk>>  GetAllAsync();
        Task<Walk> GetWalkById(Guid id);
        Task<Walk> AddWalkAsync(WalkDto walkdto);
        Task<Walk> UpdateWalkAsync(Guid id, WalkDto walkdto);
        Task<Walk> DeleteWalkAsync(Guid id);

    }
}
