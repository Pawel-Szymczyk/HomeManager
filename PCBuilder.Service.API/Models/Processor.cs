using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class Processor : PCComponentCommon
    {
        [Key]
        public Guid ProcessorId { get; set; }
        public string ProductCollection { get; set; }
        public int NumberOfCores { get; set; }
        public int NumberOfThreads { get; set; }
        public int Cache { get; set; }
        public int TDP { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProcessorBaseFrequency { get; set; }


    }
}
