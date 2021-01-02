using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models.pcbuilder
{
    public class GraphicsCard
    {
        public Guid GraphicsCardId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Dimensions { get; set; }
        public string GPU { get; set; }
        public string GPUFrequency { get; set; }
        public string BoostClock { get; set; }
        public string MemoryType { get; set; }
        public int CUDA { get; set; }
        public string PSU { get; set; }

        [Required]
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string Link { get; set; }
    }
}
