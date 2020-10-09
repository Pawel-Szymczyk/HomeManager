using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class Fan
    {
        public Guid FanId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        [Display(Name = "Image title")]
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        [Display(Name = "Upload image")]
        public IFormFile ImageFile { get; set; }

        public string Dimensions { get; set; }

        [Display(Name = "Number of fans")]
        public int NumberOfFuns { get; set; }   //spelling mistake here ;(

        [Display(Name = "PWM support")]
        public bool PWMControl { get; set; }

        [Display(Name = "RGB support")]
        public bool RGB { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
