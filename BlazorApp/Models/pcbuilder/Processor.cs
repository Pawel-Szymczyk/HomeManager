using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models.pcbuilder
{
    public class Processor
    {
        public Guid ProcessorId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string ProductCollection { get; set; }
        public int NumberOfCores { get; set; }
        public int NumberOfThreads { get; set; }
        public int Cache { get; set; }
        public int TDP { get; set; }
        public decimal ProcessorBaseFrequency { get; set; }

        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string Link { get; set; }
    }
}
