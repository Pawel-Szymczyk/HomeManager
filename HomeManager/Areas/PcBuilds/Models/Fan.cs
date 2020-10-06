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
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        public string Dimensions { get; set; }

        [Display(Name = "Number of funs")]
        public int NumberOfFuns { get; set; }

        [Display(Name = "PWM control")]
        public bool PWMControl { get; set; }
        public bool RGB { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
