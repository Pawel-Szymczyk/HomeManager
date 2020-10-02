using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class PCBuildGraphicsCard
    {
        public Guid PCBuildId { get; set; }
        public PCBuild PCBuild { get; set; }
        public Guid GraphicsCardId { get; set; }
        public GraphicsCard GraphicsCard { get; set; }
    }
}
