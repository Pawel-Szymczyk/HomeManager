using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class Other : PCComponentCommon
    {
        [Key]
        public Guid OtherId { get; set; }
        public string Description { get; set; }

        //[ForeignKey("PCBuild")]
        // Foreign key
        //public Guid? PcBuildId { get; set; }

        //// Navigation properties
        //public virtual PCBuild PCBuild { get; set; }

        //public List<PCBuildOther> PCBuildOthers { get; set; }
    }
}
