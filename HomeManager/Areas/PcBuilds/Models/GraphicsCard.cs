﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class GraphicsCard
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Dimensions { get; set; }
        public string GPU { get; set; }

        [Display(Name = "GPU frequency")]
        public string GPUFrequency { get; set; }

        [Display(Name = "Boost clock")]
        public string BoostClock { get; set; }

        [Display(Name = "Memory type")]
        public string MemoryType { get; set; }
        public int CUDA { get; set; }
        public string PSU { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
