using System;
using System.ComponentModel.DataAnnotations;

namespace PCBuilder.Service.API.Models
{
    public class CPUWatercooler : PCComponentCommon
    {
        [Key]
        public Guid Id { get; set; }
        public string Dimensions { get; set; }
        public string SocketsCompatibility { get; set; }    // list ?
        public string NumberOfFans { get; set; }
    }
}
