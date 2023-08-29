using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.View;

namespace NZWalks.API.Repository.Implementation
{
    public class RepositoryWalk : IRepositoryWalk
    {
        private readonly AppDbContext appDbContext;

        public RepositoryWalk( AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Walk> AddWalkAsync(WalkDto walkdto)
        {
            var walkDomain = new Walk
            {
                Id = Guid.NewGuid(),
                Name = walkdto.Name,
                Length = walkdto.Length,
                RegionId = walkdto.RegionId,
                WalkDifficultyId = walkdto.WalkDifficultyId
            };

            await appDbContext.AddAsync(walkDomain);
            await appDbContext.SaveChangesAsync();

            return walkDomain;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await appDbContext.Walks
                .Include(x=>x.Region)
                .Include(x=>x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetWalkById(Guid id)
        {
            var walk = await appDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(item => item.Id == id);
            
            if(walk == null)
            {
                return null;
            }

            return walk;
        }

        public async Task<Walk> UpdateWalkAsync(Guid id, WalkDto walkdto)
        {
            var walkDomain = await appDbContext.Walks.FindAsync(id);

            if(walkDomain == null )
            {
                return null;
            }

            walkDomain.Name = walkdto.Name;
            walkDomain.Length = walkdto.Length;
            walkDomain.RegionId = walkdto.RegionId;
            walkDomain.WalkDifficultyId = walkdto.WalkDifficultyId;

            await appDbContext.SaveChangesAsync();

            return walkDomain;
        }

        public async Task<Walk> DeleteWalkAsync(Guid id)
        {
            var walkDomain = await appDbContext.Walks.FindAsync(id);

            if (walkDomain == null)
            {
                return null; 
            }

            appDbContext.Walks.Remove(walkDomain);
            await appDbContext.SaveChangesAsync();

            return walkDomain;
        }
    }
}
