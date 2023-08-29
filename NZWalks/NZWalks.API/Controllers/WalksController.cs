using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;
using NZWalks.API.View;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IRepositoryWalk repositoryWalk;
        private readonly IMapper mapper;

        public WalksController(IRepositoryWalk repositoryWalk, IMapper mapper)
        {
            this.repositoryWalk = repositoryWalk;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walksDomain = await repositoryWalk.GetAllAsync();

            var walkDto = mapper.Map<List<WalkDto>>(walksDomain);

            return Ok(walksDomain);
        }


        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkById")]
        public async Task<IActionResult> GetWalkById(Guid id)
        {
            var walkDomain = await repositoryWalk.GetWalkById(id);

            if (walkDomain == null)
            {
                return NotFound();
            }

            var walkDto = mapper.Map<WalkDto>(walkDomain);

            return Ok(walkDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalk(AddRequestWalk addRequestWalk)
        {
            var walkDto = new WalkDto
            {
                Name = addRequestWalk.Name,
                Length = addRequestWalk.Length,
                RegionId = addRequestWalk.RegionId,
                WalkDifficultyId = addRequestWalk.WalkDifficultyId
            };

            var walkDomain =  await repositoryWalk.AddWalkAsync(walkDto);   

            if(walkDomain == null)
            {
                return BadRequest();
            }

            walkDto = mapper.Map<WalkDto>(walkDomain);

            // create way to get path to request data;
            return CreatedAtAction(nameof(GetWalkById),new {id = walkDto.Id}, walkDto); 
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateRequestWalk updateRequestWalk)
        {
            var walkDto = new WalkDto
            {
                Name = updateRequestWalk.Name,
                Length = updateRequestWalk.Length,
                RegionId = updateRequestWalk.RegionId,
                WalkDifficultyId = updateRequestWalk.WalkDifficultyId
            };

            var walkDomain = await repositoryWalk.UpdateWalkAsync(id, walkDto);

            if( walkDomain == null)
            {
                return NotFound();
            }

            walkDto = mapper.Map<WalkDto>(walkDomain);

            return Ok(walkDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync([FromRoute] Guid id)
        {
            var walkDomain = await repositoryWalk.DeleteWalkAsync(id);

            if(walkDomain == null)
            {
                return NotFound();
            }

            var walkDto = mapper.Map<WalkDto>(walkDomain);

            return Ok(walkDto);
        }

    }
}
