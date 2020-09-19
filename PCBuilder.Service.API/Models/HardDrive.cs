using System;
using System.ComponentModel.DataAnnotations;

namespace PCBuilder.Service.API.Models
{
    public class HardDrive : PCComponentCommon
    {
        [Key]
        public Guid Id { get; set; }

        public string Capacity { get; set; }
        public string Type { get; set; }
    }
}
