﻿using Microsoft.AspNetCore.Http;
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

        [Display(Name = "Image title")]
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        [Display(Name = "Upload image")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Series name")]
        public string ProductCollection { get; set; }

        [Display(Name = "Number of cores")]
        public int NumberOfCores { get; set; }

        [Display(Name = "Number of threads")]
        public int NumberOfThreads { get; set; }
        public int Cache { get; set; }
        public int TDP { get; set; }

        [Display(Name = "Base clock speed")]
        public decimal ProcessorBaseFrequency { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
