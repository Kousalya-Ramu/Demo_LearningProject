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
    }
}
