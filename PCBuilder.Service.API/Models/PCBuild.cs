using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("RAM")]
        public Guid? RAMId { get; set; }
        public virtual RAM RAM { get; set; }

        [ForeignKey("GraphicsCard")]
        public Guid? GraphicsCardId { get; set; }
        public virtual GraphicsCard GraphicsCard { get; set; }

        [ForeignKey("HardDrive")]
        public Guid? HardDrivedId { get; set; }
        public virtual HardDrive HardDrive { get; set; }

        [ForeignKey("CPUWatercooler")]
        public Guid? CPUWatercoolerId { get; set; }
        public virtual CPUWatercooler CPUWatercooler { get; set; }

        [ForeignKey("Fan")]
        public Guid? FanId { get; set; }
        public virtual Fan Fan { get; set; }

        [ForeignKey("PCCase")]
        public Guid? PCCaseId { get; set; }
        public virtual PCCase PCCase { get; set; }
    }
}
