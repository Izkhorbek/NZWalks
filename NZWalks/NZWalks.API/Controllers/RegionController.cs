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
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRepositoryRegions repositoryRegions;

        public RegionController(IRepositoryRegions repositoryRegions)
        {
            this.repositoryRegions = repositoryRegions;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = repositoryRegions.GetAll();

            // return DTO regions
           
            
            return Ok(await repositoryRegions.GetAll());
        }
    }
}
