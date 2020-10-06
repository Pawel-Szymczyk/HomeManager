using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class PCCase
    {
        public Guid PCCaseId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        [Display(Name = "Image Title")]
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        [Display(Name = "Upload Image")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Form factor")]
        public string FormFactor { get; set; }

        public string Color { get; set; }

        [Display(Name = "Motherboard support")]
        public string MotherboardSupport { get; set; }

        [Display(Name = "Side window")]
        public string SideWindow { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
