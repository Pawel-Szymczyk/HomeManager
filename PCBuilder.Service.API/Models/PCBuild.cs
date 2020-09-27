﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PCBuilder.Service.API.Models
{
    public class PCBuild : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Description { get; set; }

        [ForeignKey("CPUWatercooler")]
        public Guid? CPUWatercoolerId { get; set; }
        public virtual CPUWatercooler CPUWatercooler { get; set; }

        [ForeignKey("Fan")]
        public Guid? FanId { get; set; }
        public virtual Fan Fan { get; set; }

        [ForeignKey("GraphicsCard")]
        public Guid? GraphicsCardId { get; set; }
        public virtual GraphicsCard GraphicsCard { get; set; }

        [ForeignKey("HardDrive")]
        public Guid? HardDrivedId { get; set; }
        public virtual HardDrive HardDrive { get; set; }

        [ForeignKey("Motherboard")]
        public Guid? MotherboardId { get; set; }
        public virtual Motherboard Motherboard { get; set; }

        [ForeignKey("Other")]
        public Guid? OtherId { get; set; }
        public virtual Other Other { get; set; }

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

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice
        {
            get
            {
                var totalPrice = new List<decimal>();
                totalPrice.Add(this.CPUWatercooler?.Price ?? 0);
                totalPrice.Add(this.Fan?.Price ?? 0);
                totalPrice.Add(this.GraphicsCard?.Price ?? 0);
                totalPrice.Add(this.HardDrive?.Price ?? 0);
                totalPrice.Add(this.Motherboard?.Price ?? 0);
                totalPrice.Add(this.Other?.Price ?? 0);
                totalPrice.Add(this.PCCase?.Price ?? 0);
                totalPrice.Add(this.PowerSupply?.Price ?? 0);
                totalPrice.Add(this.Processor?.Price ?? 0);
                totalPrice.Add(this.RAM?.Price ?? 0);

                return totalPrice.Sum();
            }

            //set; 

        }

    }
}
