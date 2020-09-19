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
        public DbSet<Category> Categories { get; set; }
        public DbSet<State> States { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added|| e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure that specified occasionId, categoryId and StateID in entity class are not unique!
            modelBuilder.Entity<Entity>().HasIndex(x => x.OccasionId).IsUnique(false);
            modelBuilder.Entity<Entity>().HasIndex(x => x.CategoryId).IsUnique(false);
            modelBuilder.Entity<Entity>().HasIndex(x => x.StateId).IsUnique(false);

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

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "NoCategory",
                    Description = "There is no valid category for you, sorry."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Alcohol",
                    Description = "Vodka, Whisky, Wine, Beer... just stop."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Book",
                    Description = "Literature is important, just don't asleep."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Car",
                    Description = "Car one of the best man friend."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Computer",
                    Description = "Tool, toy, sense of live."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Electronics",
                    Description = "AGD, RTV ?."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Motorcycle",
                    Description = "Hobby is important don't forget about the most important."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Health",
                    Description = "Health is important, take care about it."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Hobby",
                    Description = "Hobby category, put here everything you want."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Home",
                    Description = "Home, sweet home."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Music",
                    Description = "Listen, listen... can you hear? This silence."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Other",
                    Description = "Any other category you didn't think of."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Programming",
                    Description = "One of the best jobs and hobbies ever."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Relax",
                    Description = "Put here everything everything what you think makes you relaxed."
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Savings",
                    Description = "Money, money and agian money, you need them."
                }
            );

            modelBuilder.Entity<State>().HasData(
                new State
                {
                    Id = Guid.NewGuid(),
                    Name = "PlanningToBuy",
                    Description = "I plan to buy it."
                },
                new State
                {
                    Id = Guid.NewGuid(),
                    Name = "Bought",
                    Description = "I bought it, I have it, I enjoy it."
                },
                new State
                {
                    Id = Guid.NewGuid(),
                    Name = "ThinkingOfBuying",
                    Description = "I think I need it."
                },
                new State
                {
                    Id = Guid.NewGuid(),
                    Name = "RejectedIdea",
                    Description = "I do not need it, yet."
                },
                new State
                {
                    Id = Guid.NewGuid(),
                    Name = "PostponedLater",
                    Description = "I think I need it, but not now."
                }
            );

        }
    }
}
