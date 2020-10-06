﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class PowerSupply
    {
        public Guid PowerSupplyId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Manufacturer { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        public string Model { get; set; }

        public string Power { get; set; }

        public string Color { get; set; }

        public string Certificate { get; set; }

        [Display(Name = "Modular cables")]
        public bool ModularCables { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }

    }
}
