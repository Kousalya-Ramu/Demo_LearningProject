using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_learningWeb_Api.Models
{
    public class Region
    {
        public Guid id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public double lat { get; set; }

        public double Long { get; set; }

        public long Populatation { get; set; }
        //Navigation property i region can have multiple  walk insde the class

        public IEnumerable<Walk> walks { get; set; }
      
    }
}
