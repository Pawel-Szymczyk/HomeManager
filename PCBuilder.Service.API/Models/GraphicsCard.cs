using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class GraphicsCard : PCComponentCommon
    {
        [Key]
        public Guid Id { get; set; }

    }
}
