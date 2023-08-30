using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.View;
using System.Collections.Immutable;

namespace NZWalks.API.Repository.Implementation
{
    public class RepositoryWalkDifficulty : IRepositoryWalkDifficulty
    {
        private readonly AppDbContext appDbContext;

        public RepositoryWalkDifficulty(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

      

        public async Task<IEnumerable<WalkDifficulty>> GetWalkDifficultyAsync()
        {
            return await appDbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetWalkDifficultybyId(Guid id)
        {
            var walkDiffDomain = await appDbContext.WalkDifficulty.FindAsync(id);

            if(walkDiffDomain == null)
            {
                return null;
            }

            return walkDiffDomain;
        }

        public async Task<WalkDifficulty> UpdateWalkDifficulty(Guid id, WalkDifficultyDto walkDifficultyDto)
        {
            var walkDiffDomain = await appDbContext.WalkDifficulty.FindAsync(id);

            if( walkDiffDomain == null)
            {
                return null;
            }

            walkDiffDomain.Code = walkDifficultyDto.Code;

            await appDbContext.SaveChangesAsync();

            return walkDiffDomain;
        }

        public async Task<WalkDifficulty> AddWalkDifficulty(WalkDifficultyDto difficultydto)
        {
            var walkDifficulty = new WalkDifficulty
            {
                Id = Guid.NewGuid(),
                Code = difficultydto.Code
            };

            await appDbContext.AddAsync(walkDifficulty);
            await appDbContext.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteWalkDifficulty(Guid id)
        {
            var walkDiffDomain = await appDbContext.WalkDifficulty.FindAsync(id);
            
            if(walkDiffDomain == null)
            {
                return null;
            }

            appDbContext.WalkDifficulty.Remove(walkDiffDomain);
            await appDbContext.SaveChangesAsync();

            return walkDiffDomain;
        }
    }
}
