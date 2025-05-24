using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using UAWalks.API.Model.Domain;
using UAWalks.API.Model.DTO;
using UAWalks.API.Repository;

namespace UAWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<WalkDto>>(await walkRepository.GetAsync()));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
           var result = await walkRepository.GetAsyncById(id);
            if (result == null) return NotFound();

            return Ok(mapper.Map<WalkDto>(result));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomain = mapper.Map<Walk>(addWalkRequestDto);
            await walkRepository.CreateAsync(walkDomain);

            return Ok(mapper.Map<WalkDto>(walkDomain));
        }

        [HttpPut]
        [Route("{id:guid}")]   
        public async Task<IActionResult> Update([FromRoute]Guid id,[FromBody]UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomain = mapper.Map<Walk>(updateWalkRequestDto);
            walkDomain= await walkRepository.UpdateAsync(id, walkDomain);
            if (walkDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomain));
        }

        [HttpDelete]
        [Route("{id:guid}")]  
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var walkdomain = await walkRepository.DeleteAsync(id);
            if (walkdomain == null) return NotFound();

            return Ok(mapper.Map<WalkDto>(walkdomain));
        }
    }
}
