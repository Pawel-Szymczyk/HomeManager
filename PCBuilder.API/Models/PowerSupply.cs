using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class PowerSupply : PCComponentCommon
    {
        [Key]
        public Guid PowerSupplyId { get; set; }
        public string Model { get; set; }
        public string Power { get; set; }
        public string Color { get; set; }
        public string Certificate { get; set; }
        public bool ModularCables { get; set; }
    }
}
