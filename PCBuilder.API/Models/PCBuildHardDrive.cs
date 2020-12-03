using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class PCBuildHardDrive
    {
        public Guid PCBuildId { get; set; }
        public PCBuild PCBuild { get; set; }
        public Guid HardDriveId { get; set; }
        public HardDrive HardDrive { get; set; }
    }
}
