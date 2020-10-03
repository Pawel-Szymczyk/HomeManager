using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCBuilder.Service.API.Models
{
    public class CPUWatercooler : PCComponentCommon
    {
        [Key]
        public Guid CPUWatercoolerId { get; set; }
        public string Dimensions { get; set; }
        public string SocketsCompatibility { get; set; }    // list ?
        public string NumberOfFans { get; set; }

        //public List<PCBuild> PCBuilds { get; set; }
        //public PCBuild PCBuild { get; set; }
    } 
}
