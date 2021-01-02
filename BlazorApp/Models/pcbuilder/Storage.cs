using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models.pcbuilder
{
    public class Storage
    {
        public Guid HardDriveId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Capacity { get; set; }
        public string Type { get; set; }

        [Required]
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string Link { get; set; }
    }
}
