using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class Configuration
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        [Display(Name = "Total price")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }



        //[ForeignKey("CPUWatercooler")]
        //public Guid? CPUWatercoolerId { get; set; }
        //public virtual CPUWatercooler CPUWatercooler { get; set; }
        public CPUWatercooler CPUWatercooler { get; set; }

        //[ForeignKey("Fan")]
        //public Guid? FanId { get; set; }
        //public virtual Fan Fan { get; set; }
        public Fan Fan { get; set; }

        //[ForeignKey("GraphicsCard")]
        //public Guid? GraphicsCardId { get; set; }
        //public virtual GraphicsCard GraphicsCard { get; set; }
        public GraphicsCard GraphicsCard { get; set; }

        //[ForeignKey("HardDrive")]
        //public Guid? HardDrivedId { get; set; }
        //public virtual HardDrive HardDrive { get; set; }
        public HardDrive HardDrive { get; set; }

        //[ForeignKey("Motherboard")]
        //public Guid? MotherboardId { get; set; }
        //public virtual Motherboard Motherboard { get; set; }
        public Motherboard Motherboard { get; set; }

        //[ForeignKey("Other")]
        //public Guid? OtherId { get; set; }
        //public virtual Other Other { get; set; }
        public Other Other { get; set; }

        //[ForeignKey("PCCase")]
        //public Guid? PCCaseId { get; set; }
        //public virtual PCCase PCCase { get; set; }
        public PCCase PCCase { get; set; }

        //[ForeignKey("PowerSupply")]
        //public Guid? PowerSupplyId { get; set; }
        //public virtual PowerSupply PowerSupply { get; set; }
        public PowerSupply PowerSupply { get; set; }

        //[ForeignKey("Processor")]
        //public Guid? ProcessorId { get; set; }
        //public virtual Processor Processor { get; set; }
        public Processor Processor { get; set; }

        //[ForeignKey("RAM")]
        //public Guid? RAMId { get; set; }
        //public virtual RAM RAM { get; set; }
        public RAM RAM { get; set; }
    }
}
