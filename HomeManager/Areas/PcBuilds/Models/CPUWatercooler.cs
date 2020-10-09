using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class CPUWatercooler
    {
        public Guid CPUWatercoolerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        [Display(Name = "Image title")]
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        [Display(Name = "Upload image")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Radiator dimensions")]
        public string Dimensions { get; set; }

        [Display(Name = "Sockets compatibility")]
        public string SocketsCompatibility { get; set; }    // list ?

        [Display(Name = "Number of fans")]
        public string NumberOfFans { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
