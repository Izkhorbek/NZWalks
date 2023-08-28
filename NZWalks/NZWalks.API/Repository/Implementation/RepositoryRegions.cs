using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

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

        public async Task<Region>  GetbyId(Guid Id)
        {
            return await appDbContext.Regions.FirstOrDefaultAsync(item => item.Id == Id);
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            region.Id = Guid.NewGuid();

            await appDbContext.Regions.AddAsync(region);

            await appDbContext.SaveChangesAsync();
            
            return region;
        }

        public async Task<Region> DeleteRegionAsync(Guid Id)
        {
            var region = await appDbContext.Regions.FirstOrDefaultAsync(region => region.Id == Id);

            if(region == null)
            {
                return null; 
            }

            appDbContext.Regions.Remove(region);
            await appDbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> UpdateRegionAsync(Guid Id, RegionDto regionDto)
        {
            var region =  appDbContext.Regions.FirstOrDefault(item =>  item.Id == Id);   
            
            if(region == null)
            {
                return null;
            }

            region.Code =  regionDto.Code;
            region.Name = regionDto.Name;
            region.Area = regionDto.Area;
            region.Lat = regionDto.Lat;
            region.Long = regionDto.Long;
            region.Population = regionDto.Population;

            await appDbContext.SaveChangesAsync();

            return region;
        
        }
    }
}

