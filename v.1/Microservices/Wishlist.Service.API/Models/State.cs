using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wishlist.Service.API.Models
{
    //public enum State
    //{
    //    PlanningToBuy = 0,
    //    Bought = 1,
    //    ThinkingOfBuying = 2,
    //    RejectedIdea = 3,
    //    PostponedLater = 4
    //}

    public class State
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
