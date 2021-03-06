﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wishlist.Service.API.Models
{
    //public enum Category
    //{
    //    NoCategory = 0,
    //    Alcohol = 1,
    //    Book = 2,
    //    Car = 3,
    //    Computer = 4,
    //    Electronics = 5,
    //    Motorcycle = 6,
    //    Health = 7, 
    //    Hobby = 8,
    //    Home = 9,
    //    Music = 10,
    //    Other = 11,
    //    Programming = 12, 
    //    Relax = 13,
    //    Savings = 14
    //}

    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
