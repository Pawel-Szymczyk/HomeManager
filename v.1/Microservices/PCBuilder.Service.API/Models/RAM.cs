using System;
using System.ComponentModel.DataAnnotations;

namespace PCBuilder.Service.API.Models
{
    public class RAM : PCComponentCommon
    {
        [Key]
        public Guid RamId { get; set; }
        public string MemoryType { get; set; }
        public string MemorySpeed { get; set; }
        public string Capacity { get; set; }
        public string ChipsetCompatibility { get; set; }
        public int NumberOfModules { get; set; }
    }
}
