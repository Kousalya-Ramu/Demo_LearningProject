using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_learningWeb_Api.Models.DTO
{
    public class UpdateregionRequest
    {
       
        public string Name { get; set; }
        public string Area { get; set; }
        public double lat { get; set; }

        public double Long { get; set; }
        public object Populatation { get; set; }
    }
}
