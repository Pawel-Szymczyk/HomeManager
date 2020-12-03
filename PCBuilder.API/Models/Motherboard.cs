using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class Motherboard : PCComponentCommon
    {
        [Key]
        public Guid MotherboardId { get; set; }
        public string CPU { get; set; }
        public string Chipset { get; set; }
        public string Socket { get; set; }
        public string Memory { get; set; }
        public string FormFactor { get; set; }
    }
}
