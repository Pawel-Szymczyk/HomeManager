using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class Processor
    {
        public Guid ProcessorId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        [Display(Name = "Image Title")]
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        [Display(Name = "Upload Image")]
        public IFormFile ImageFile { get; set; }

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
