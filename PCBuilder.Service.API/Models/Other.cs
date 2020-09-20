using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Models
{
    public class Other : PCComponentCommon
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
