using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_learningWeb_Api.Models
{
    public class Walk
    {
        public Guid id { get; set; }
       
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionId { get; set; }

      

        //Navigation property

        public Region Region { get; set; }
        public WalkDifficultyId walkDifficulty { get; set; }
    }
}
