using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PCBuilder.Service.API.Models
{
    public class PCBuild : BaseEntity
    {
        //public PCBuild()
        //{
        //    this.Others = new HashSet<Other>();
        //}


        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }
        //public string Description { get; set; }

        //[ForeignKey("CPUWatercooler")]
        //public Guid? CPUWatercoolerId { get; set; }
        //public virtual CPUWatercooler CPUWatercooler { get; set; }

        //[ForeignKey("Fan")]
        //public Guid? FanId { get; set; }
        //public virtual Fan Fan { get; set; }

        //[ForeignKey("GraphicsCard")]
        //public Guid? GraphicsCardId { get; set; }
        //public virtual GraphicsCard GraphicsCard { get; set; }

        //[ForeignKey("HardDrive")]
        //public Guid? HardDrivedId { get; set; }
        //public virtual HardDrive HardDrive { get; set; }

        //[ForeignKey("Motherboard")]
        //public Guid? MotherboardId { get; set; }
        //public virtual Motherboard Motherboard { get; set; }



        ////[ForeignKey("Other")]
        ////public Guid? OtherId { get; set; }

        //// Navigation property
        //public virtual ICollection<Other> Others { get; set; }    // todo make it a list




        //[ForeignKey("PCCase")]
        //public Guid? PCCaseId { get; set; }
        //public virtual PCCase PCCase { get; set; }

        //[ForeignKey("PowerSupply")]
        //public Guid? PowerSupplyId { get; set; }
        //public virtual PowerSupply PowerSupply { get; set; }

        //[ForeignKey("Processor")]
        //public Guid? ProcessorId { get; set; }
        //public virtual Processor Processor { get; set; }

        //[ForeignKey("RAM")]
        //public Guid? RAMId { get; set; }
        //public virtual RAM RAM { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal TotalPrice
        //{
        //    get
        //    {
        //        var totalPrice = new List<decimal>
        //        {
        //            this.CPUWatercooler?.Price ?? 0,
        //            this.Fan?.Price ?? 0,
        //            this.GraphicsCard?.Price ?? 0,
        //            this.HardDrive?.Price ?? 0,
        //            this.Motherboard?.Price ?? 0,
        //            //this.Other?.Price ?? 0,
        //            this.PCCase?.Price ?? 0,
        //            this.PowerSupply?.Price ?? 0,
        //            this.Processor?.Price ?? 0,
        //            this.RAM?.Price ?? 0
        //        };

        //        if (Others != null)
        //        {
        //            foreach (var item in Others)
        //            {
        //                totalPrice.Add(item?.Price ?? 0);
        //            }
        //        }

        //        return totalPrice.Sum();
        //    }

        //    //set; 

        //}



        public Guid PCBuildId { get; set; }
        public string Description { get; set; }

        public List<PCBuildGraphicsCard> PCBuildGraphicsCards { get; set; }
        public List<PCBuildHardDrive> PCBuildHardDrives { get; set; }
        public List<PCBuildOther> PCBuildOthers { get; set; }

    }
}
