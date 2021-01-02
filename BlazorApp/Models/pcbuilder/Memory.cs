using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models.pcbuilder
{
    public class Memory
    {
        public Guid RamId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string MemoryType { get; set; }
        public string MemorySpeed { get; set; }
        public string Capacity { get; set; }
        public string ChipsetCompatibility { get; set; }
        public int NumberOfModules { get; set; }

        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string Link { get; set; }
    }
}
