using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UAWalks.API.Model.Domain;
using UAWalks.API.Model.DTO;
using UAWalks.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UAWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET: api/<RegionsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Getting all the regions
            var regions = await regionRepository.GetAllAsync();
            //returning the regionsDto
            return Ok(mapper.Map<List<RegionDto>>(regions));
        }

        // GET api/<RegionsController>/5
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            //Getting the region by id
            var region = await regionRepository.GetByIdAsync(id);
            //Checking if the region is null
            if (region == null)
            {
                return NotFound();
            }
            //Returning the RegionDto
            return Ok(mapper.Map<RegionDto>(region));


        }

        // POST api/<RegionsController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]AddRegionRequestDto addRegionRequest)
        {
            //Mapping the DTO to Domain
            var regionDomain = mapper.Map<Region>(addRegionRequest);

            //Adding the region to the database
            await regionRepository.AddAsync(regionDomain);

            //Mapping the domain to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            //Returning the created region
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

        }

        // PUT api/<RegionsController>/5
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateRegionsRequestDto updateReionsRequestDto)
        {
            //Mapping the DTO to Domain
            var regionDomain = mapper.Map<Region>(updateReionsRequestDto);
            //Updating the region in the database
            var UpRegion = await regionRepository.UpdateAsync(id, regionDomain);

            if (UpRegion == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(UpRegion));
        }

        // DELETE api/<RegionsController>/5
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.DeleteAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map<RegionDto>(regionDomain));
            }
        }
    }
}
