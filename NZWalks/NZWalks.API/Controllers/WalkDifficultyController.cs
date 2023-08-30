using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Profiles;
using NZWalks.API.Repository;
using NZWalks.API.View;
using System.Diagnostics.CodeAnalysis;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkDifficultyController : ControllerBase
    {
        private readonly IRepositoryWalkDifficulty repositoryWalkDifficulty;
        private readonly IMapper mapper;

        public WalkDifficultyController(IRepositoryWalkDifficulty repositoryWalkDifficulty, IMapper mapper)
        {
            this.repositoryWalkDifficulty = repositoryWalkDifficulty;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalkDifficultyAsync()
        {
            var walkDiffDomain = await repositoryWalkDifficulty.GetWalkDifficultyAsync();

            var walkDiffDto = mapper.Map<List<WalkDifficultyDto>>(walkDiffDomain);

            return Ok(walkDiffDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkDifficultyAsync([FromRoute] Guid id)
        {
            var walkDiffDomain = await repositoryWalkDifficulty.GetWalkDifficultybyId(id);

            if(walkDiffDomain == null)
            {
                return NotFound();
            }

            var walkDiffDto = mapper.Map<WalkDifficultyDto>(walkDiffDomain);

            return Ok(walkDiffDto);

        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficultyAsync(AddRequestWalkDifficulty addRequestWalkDifficulty)
        {
            var walkDiffDto = new WalkDifficultyDto
            {
                Code = addRequestWalkDifficulty.Code
            };

            var walkDiffDomain = await repositoryWalkDifficulty.AddWalkDifficulty(walkDiffDto);

            if(walkDiffDomain == null)
            {
                return NotFound();
            }

            walkDiffDto = mapper.Map<WalkDifficultyDto>(walkDiffDomain);

            return Ok(walkDiffDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync([FromRoute] Guid id, [FromBody] UpdateRequestWalkDifficulty updateRequestWalkDifficulty)
        {
            var walkDiffDto = new WalkDifficultyDto
            {
                Code = updateRequestWalkDifficulty.Code,
            };

            var walkDiffDomain = await repositoryWalkDifficulty.UpdateWalkDifficulty(id, walkDiffDto);
             
            if( walkDiffDomain == null)
            {
                return NotFound();
            }

            walkDiffDto = mapper.Map<WalkDifficultyDto>(walkDiffDomain);

            return Ok(walkDiffDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficultyAsync(Guid id)
        {
            var walkDiffDomain = await repositoryWalkDifficulty.DeleteWalkDifficulty(id);

            if(walkDiffDomain == null)
            {
                return NotFound();
            }

            var walkDiffDto = mapper.Map<WalkDifficultyDto>(walkDiffDomain);

            return Ok(walkDiffDto);
        }

    }
}
