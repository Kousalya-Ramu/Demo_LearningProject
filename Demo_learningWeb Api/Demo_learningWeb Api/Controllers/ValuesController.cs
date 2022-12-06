using Demo_learningWeb_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_learningWeb_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllRegion()
        {
            var regions = new List<Region>()
                         {
                             new Region
                             {
                                 id= Guid.NewGuid(),
                                 Name = "Welligton",
                                 Code = "WLG",
                                 Area = "22678367",
                                 lat = 1.2345,
                                 Long = 299.03,
                                 Populatation = 900000

                             }
                         };
            return Ok(regions);
        }
    }
}

