﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required , MaxLength(150)]
        public string  PName { get; set; }

        [Required ,MaxLength(250)]
        public string PDescription { get; set; }

        public decimal Price { get; set; }

        public byte Rate { get; set; }

        public int Quantity { get; set; }


        [Required]
        public string ImageUrl { get; set; }


        //Navigations

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public  virtual  Category? Category { get; set; }


        public virtual  Brand? Brand { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; } = new HashSet<Review>();

       


        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Cart>? Carts { get; set; }
        public virtual ICollection<WishList>? WishLists { get; set; }

 




    }
}
