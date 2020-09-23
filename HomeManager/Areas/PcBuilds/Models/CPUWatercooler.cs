using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class CPUWatercooler
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Dimensions { get; set; }

        [Display(Name = "Sockets compatibility")]
        public string SocketsCompatibility { get; set; }    // list ?

        [Display(Name = "Number of fans")]
        public string NumberOfFans { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
