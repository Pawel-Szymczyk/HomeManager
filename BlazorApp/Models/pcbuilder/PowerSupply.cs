using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models.pcbuilder
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
        public bool ModularCables { get; set; }

        [Required]
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string Link { get; set; }
    }
}
