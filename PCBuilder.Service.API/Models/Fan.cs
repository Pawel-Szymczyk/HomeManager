using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class Fan : PCComponentCommon
    {
        [Key]
        public Guid Id { get; set; }

        public string Dimensions { get; set; }
        public int NumberOfFuns { get; set; }
        public bool PWMControl { get; set; }
        public bool RGB { get; set; }
    }
}
