using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PCBuilder.Service.API.Models
{
    public class PCBuild : BaseEntity
    {
        

        public Guid PCBuildId { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }


        [ForeignKey("CPUWatercooler")]
        public Guid? CPUWatercoolerId { get; set; }
        public CPUWatercooler CPUWatercooler { get; set; }

        [ForeignKey("Fan")]
        public Guid? FanId { get; set; }
        public virtual Fan Fan { get; set; }

        [ForeignKey("Motherboard")]
        public Guid? MotherboardId { get; set; }
        public virtual Motherboard Motherboard { get; set; }

        [ForeignKey("PCCase")]
        public Guid? PCCaseId { get; set; }
        public virtual PCCase PCCase { get; set; }

        [ForeignKey("PowerSupply")]
        public Guid? PowerSupplyId { get; set; }
        public virtual PowerSupply PowerSupply { get; set; }

        [ForeignKey("Processor")]
        public Guid? ProcessorId { get; set; }
        public virtual Processor Processor { get; set; }

        [ForeignKey("RAM")]
        public Guid? RAMId { get; set; }
        public virtual RAM RAM { get; set; }

        public List<PCBuildGraphicsCard> PCBuildGraphicsCards { get; set; }
        public List<PCBuildHardDrive> PCBuildHardDrives { get; set; }
        public List<PCBuildOther> PCBuildOthers { get; set; }

    }
}
