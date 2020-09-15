using System;
using System.ComponentModel.DataAnnotations;

namespace Wishlist.Service.API.Database.Entities
{
    public class WishlistEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public decimal Price { get; set; }
        public Occasion Occasion { get; set; }
        public State State { get; set; }
        public Category Category { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}
