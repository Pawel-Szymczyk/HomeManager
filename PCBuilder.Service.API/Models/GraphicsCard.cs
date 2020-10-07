using System;
using System.ComponentModel.DataAnnotations;

namespace PCBuilder.Service.API.Models
{
    public class GraphicsCard : PCComponentCommon
    {
        [Key]
        public Guid GraphicsCardId { get; set; }
        public string Dimensions { get; set; }
        public string GPU { get; set; }
        public string GPUFrequency { get; set; }
        public string BoostClock { get; set; }
        public string MemoryType { get; set; }
        public int CUDA { get; set; }
        public string PSU { get; set; }
        public int Qty { get; set; }

    }
}
