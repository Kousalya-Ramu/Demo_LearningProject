using AutoMapper;
using Demo_learningWeb_Api.Models;
using Demo_learningWeb_Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_learningWeb_Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository repository;

        public IMapper Mapper { get; }



        public RegionsController(IRegionRepository repository, IMapper mapper)

        {
            this.repository = repository;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegion()
        {
            var regioons = await repository.GetAllAsync();


            //var regionDto = new List<Models.DTO.RegionDto>();
            //regioons.ToList().ForEach(region =>
            //{
            //    var regionDto = new Models.DTO.RegionDto()
            //    {
            //        id = region.id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        lat = region.lat,
            //        Long = region.Long,
            //        Populatation = region.Populatation,

            //};
            //    regionDto.Equals(regionDto);
            //});

            var regionsDTO = Mapper.Map<List<Models.DTO.RegionDto>>(regioons);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegisterAsync(Guid id)
        {
            var region = await repository.GetAsync(id);
            return Ok(region);
        }
        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            //Requuest to domain models
            var region = new Models.DTO.RegionDto()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                lat = addRegionRequest.lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Populatation = addRegionRequest.Populatation
            };
            region = await repository.AddAsyn(region);
            var regionDTO = new Models.DTO.RegionDto
            {
                id = region.id,
                Code = region.Code,
                Area = region.Area,
                lat = region.lat,
                Long = region.Long,
                Name = region.Name,
                Populatation = region.Populatation
            };

            return CreatedAtAction(nameof(GetAllRegion), new { id = regionDTO.id }, regionDTO);
            //pass details to repo
            //convert back to dto

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegisterAsync(Guid id, Region region)
        {
            //get the region from database
            var regiondelete = await repository.DeleteAsync(id);
            //Not found back
            if (regiondelete == null)
            {
                return NotFound();
            }

            //convert response back to DTO
            var regionDTO = new Models.DTO.RegionDto
            {
                id = region.id,
                Code = region.Code,
                Area = region.Area,
                lat = region.lat,
                Long = region.Long,
                Name = region.Name,
                Populatation = region.Populatation
            };
            //return ok response
            return Ok(regionDTO);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> updateregisterAsync([FromRoute] Guid id,[FromBody] Models.DTO.UpdateregionRequest updateregionRequest)
        {
            // Convert the dto to domain
            var region = new Models.DTO.RegionDto
            {
               
               
                Area = updateregionRequest.Area,
                lat = updateregionRequest.lat,
                Long = updateregionRequest.Long,
                Name = updateregionRequest.Name,
                Populatation = updateregionRequest.Populatation
            };
            //update the region using repository
            
            region = await repository.UpdateAsync(id, region);

            if(region == null)
            {
                return NotFound();
            }
            // if null then NotFound
            var regionDTO = new Models.DTO.RegionDto
            {
                id = region.id,
                Code = region.Code,
                Area = region.Area,
                lat = region.lat,
                Long = region.Long,
                Name = region.Name,
                Populatation = region.Populatation
            };
            //convert domain back to dTo
            return Ok(regionDTO);
            // return ok response
        }
       
        
    }
}

