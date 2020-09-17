using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public abstract class PCComponentCommon
    {
        public string Name { get; set; }
        public string Link { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        //public List<byte> Images { get; set; } // for later
    }
}
