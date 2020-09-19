﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class PCBuild : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }


        [ForeignKey("Processor")]
        public Guid? ProcessorId { get; set; }
        public virtual Processor Processor { get; set; }

        [ForeignKey("Motherboard")]
        public Guid? MotherboardId { get; set; }
        public virtual Motherboard Motherboard { get; set; }
    }
}
