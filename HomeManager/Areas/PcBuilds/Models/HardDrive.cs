﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class HardDrive
    {
        public Guid HardDriveId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        [Display(Name = "Image Title")]
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        [Display(Name = "Upload Image")]
        public IFormFile ImageFile { get; set; }

        public string Capacity { get; set; }

        public string Type { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
