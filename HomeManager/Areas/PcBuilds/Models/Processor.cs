using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class Processor
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
     
        [Display(Name = "Product Collection")]
        public string ProductCollection { get; set; }

        [Display(Name = "Number of Cores")]
        public int NumberOfCores { get; set; }

        [Display(Name = "Number of Threads")]
        public int NumberOfThreads { get; set; }
        public int Cache { get; set; }
        public int TDP { get; set; }

        [Display(Name = "Base Frequency")]
        public decimal ProcessorBaseFrequency { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
