using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;
using NZWalks.API.View;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;

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

        [HttpGet]
        [Route("{Id:Guid}")]
        [ActionName("GetbyId")]
        public async Task<IActionResult> GetbyId([FromRoute] Guid Id)
        {
            var region = await repositoryRegions.GetbyId(Id);

            if(region == null) 
            {
                return NotFound();
            }

            var regionDto = mapper.Map<RegionDto>(region);  

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRequestRegion addRequestRegion)
        {
            // change to Domain Model
            var region = new Region
            {
                Code = addRequestRegion.Code,
                Name = addRequestRegion.Name,
                Area = addRequestRegion.Area,
                Lat = addRequestRegion.Lat,
                Long = addRequestRegion.Long,
                Population = addRequestRegion.Population
            };

            // Send to add it To database 
            await repositoryRegions.AddRegionAsync(region);

            // Map it to response (DTO)
            var regionDto = mapper.Map<RegionDto>(region);

            return CreatedAtAction(nameof(GetbyId), new { id = regionDto.Id }, regionDto);
            //return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteRegionAsync([FromRoute] Guid Id)
        {
            var region = await repositoryRegions.DeleteRegionAsync(Id);
            
            if(region == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid Id, [FromBody] UpdateRequestRegion updateRequestRegion)
        {
            var regionDto = new RegionDto
            {
                Code = updateRequestRegion.Code,
                Name = updateRequestRegion.Name,
                Area = updateRequestRegion.Area,
                Lat = updateRequestRegion.Lat,
                Long = updateRequestRegion.Long,
                Population = updateRequestRegion.Population
            };

            var region = await repositoryRegions.UpdateRegionAsync(Id, regionDto);

            if(region == null)
            {
                return NotFound();
            }

            regionDto = mapper.Map<RegionDto>(region);
            
            return Ok(regionDto);
        }
    }
}
