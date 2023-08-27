using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository.Implementation
{
    public class RepositoryRegions : IRepositoryRegions
    {
        private readonly AppDbContext appDbContext;

        public RepositoryRegions(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }

         
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
           return await appDbContext.Regions.ToListAsync();  
        }
    }
}
