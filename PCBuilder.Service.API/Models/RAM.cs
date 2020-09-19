using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class RAM : PCComponentCommon
    {
        [Key]
        public Guid Id { get; set; }
        public string MemoryType { get; set; }
        public string MemorySpeed { get; set; }
        public string Capacity { get; set; }
        public string ChipsetCompatibility { get; set; }
        public int NumberOfModules { get; set; }
    }
}
