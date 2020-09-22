using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class Motherboard
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CPU { get; set; }

        public string Chipset { get; set; }

        public string Socket { get; set; }

        public string Memory { get; set; }

        [Display(Name = "Form factor")]
        public string FormFactor { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }

    }
}
