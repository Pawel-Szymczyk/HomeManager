using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class PCCase : PCComponentCommon
    {
        [Key]
        public Guid PCCaseId { get; set; }
        public string FormFactor { get; set; }
        public string Color { get; set; }
        public string MotherboardSupport { get; set; }
        public string SideWindow { get; set; }

    }
}
