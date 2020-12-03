using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class PCBuildOther
    {
        public Guid PCBuildId { get; set; }
        public PCBuild PCBuild { get; set; }
        public Guid OtherId { get; set; }
        public Other Other { get; set; }

    }
}
