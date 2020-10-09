using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class RAM
    {
        public Guid RamId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        [Display(Name = "Image title")]
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        [Display(Name = "Upload image")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Memory type")]
        public string MemoryType { get; set; }

        [Display(Name = "Memory speed")]
        public string MemorySpeed { get; set; }

        public string Capacity { get; set; }

        [Display(Name = "Chipset compatibility")]
        public string ChipsetCompatibility { get; set; }

        [Display(Name = "Number of modules")]
        public int NumberOfModules { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
