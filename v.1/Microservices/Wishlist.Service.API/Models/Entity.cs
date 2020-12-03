using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wishlist.Service.API.Models
{
    public class Entity : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }


        [ForeignKey("Occasion")]
        public Guid? OccasionId { get; set; }
        public virtual Occasion Occasion { get; set; }

        [ForeignKey("State")]
        public Guid? StateId { get; set; }
        public virtual State State { get; set; }

        [ForeignKey("Category")]
        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }
}
