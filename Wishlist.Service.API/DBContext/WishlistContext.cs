using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Service.API.Models;

namespace Wishlist.Service.API.DBContext
{
    public class WishlistContext : DbContext
    {
        public WishlistContext(DbContextOptions<WishlistContext> options) : base(options)
        {
        }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<Occasion> Occasions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure that specified occasionId in entity class is not unique!
            modelBuilder.Entity<Entity>().HasIndex(x => x.OccasionId).IsUnique(false);

            modelBuilder.Entity<Occasion>().HasData(
                new Occasion
                {
                    Id = Guid.NewGuid(),
                    Name = "NoOccasion",
                    Description = "There is no occasion, but don't forget about yourself."
                },
                new Occasion
                {
                    Id = Guid.NewGuid(),
                    Name = "BirthdayPresent",
                    Description = "Someone celebrates birthday, don't forget about a nice present."
                },
                new Occasion
                {
                    Id = Guid.NewGuid(),
                    Name = "ChristmasPresent",
                    Description = "Christmas time, there is no better time for presents."
                },
                new Occasion
                {
                    Id = Guid.NewGuid(),
                    Name = "Movement",
                    Description = "Need more stuf, movement is great opportunity to rid of old things."
                },
                new Occasion
                {
                    Id = Guid.NewGuid(),
                    Name = "Others",
                    Description = "Any other situation you didn't think of."
                }
            );
        }
    }
}
