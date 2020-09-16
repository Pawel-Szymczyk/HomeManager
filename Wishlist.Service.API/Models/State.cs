using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wishlist.Service.API.Models
{
    public enum State
    {
        PlanningToBuy = 0,
        Bought = 1,
        ThinkingOfBuying = 2,
        RejectedIdea = 3,
        PostponedLater = 4
    }
}
