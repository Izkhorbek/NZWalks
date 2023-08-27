using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    // https:localhost:12354/api/Region
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRepositoryRegions repositoryRegions;
        private readonly IMapper mapper;

        public RegionController(IRepositoryRegions repositoryRegions, IMapper mapper)
        {
            this.repositoryRegions = repositoryRegions;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await repositoryRegions.GetAllAsync();

            #region using without AutoMapper
            //Return RegionsDto 
            // var regionsDto = new List<RegionDto>();

            //regions.ToList().ForEach(region =>
            //{
            //    var regionDto = new RegionDto()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population
            //    };

            //    regionsDto.Add(regionDto);
            //}); 
            #endregion

            var regionsDto = mapper.Map<List<RegionDto>>(regions);

            return Ok(regionsDto);
        }
    }
}
