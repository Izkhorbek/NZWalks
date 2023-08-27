using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IRepositoryRegions
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
