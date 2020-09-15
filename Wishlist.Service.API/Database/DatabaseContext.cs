using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Service.API.Database.Entities;

namespace Wishlist.Service.API.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<WishlistEntity> WishlistEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=(localdb)\mssqllocaldb; Database=WishlistService; Trusted_Connection = True;");
        }
    }
}
