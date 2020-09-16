using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wishlist.Service.API.Models
{ 
    //public enum Occasion
    //{
    //    NoOccasion = 0,
    //    BirthdayPresent = 1,
    //    ChristmasPresent = 2,
    //    Movement = 3,
    //    Others = 4
    //}

    public class Occasion
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual Entity Entity { get; set; }
    }
}
