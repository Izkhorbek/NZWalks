using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.View;

namespace NZWalks.API.Repository
{
    public interface IRepositoryRegions
    {
        Task<IEnumerable<Region>> GetAllAsync();

        Task<Region> GetbyId(Guid Id);

        Task<Region> AddRegionAsync(Region region);

        Task<Region> DeleteRegionAsync(Guid Id);

        Task<Region> UpdateRegionAsync(Guid Id, RegionDto regionDto);

    }
}
