using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.pcbuilder
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

        public int NumberOfFuns { get; set; }   //spelling mistake here ;(

        public bool PWMControl { get; set; }

        public bool RGB { get; set; }

        [Required]
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string Link { get; set; }
    }
}
