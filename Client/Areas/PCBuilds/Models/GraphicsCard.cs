using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Areas.PCBuilds.Models
{
    public class GraphicsCard
    {
        public Guid GraphicsCardId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Manufacturer { get; set; }

        [Display(Name = "Image title")]
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        [Display(Name = "Upload image")]
        public IFormFile ImageFile { get; set; }

        public string Dimensions { get; set; }

        [Display(Name = "Graphics processing / engine")]
        public string GPU { get; set; }

        [Display(Name = "Core / base clock")]
        public string GPUFrequency { get; set; }

        [Display(Name = "Boost clock")]
        public string BoostClock { get; set; }

        [Display(Name = "Memory type")]
        public string MemoryType { get; set; }
        public int CUDA { get; set; }

        [Display(Name = "Recommended PSU")]
        public string PSU { get; set; }

        [Required]
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }

        
    }
}
